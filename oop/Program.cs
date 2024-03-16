using System;
namespace oop
{
    class Program
    {
        //bir sınıf bir sınıfı inheritance edebilir.
        //bir sınıf birden fazla interface i implementation edebilir.
        static void Main(string[] args)
        {
            /**  CreditManager creditManager = new CreditManager();
              creditManager.Calculate();
              creditManager.Save();

              Customer customer = new Customer();//örneğini (instance) oluşturmak
              customer.Id = 1;
              //customer.Name = "Ümran";
              //customer.Surname = "Uğurlu";
              //customer.Nationalidentity = "123456789";
              customer.Address = "Fındıklı";
              customer.City = "İstanbul";

              CustomerManager customerManager = new CustomerManager(customer);
              customerManager.Save();
              customerManager.Update();

              CustomerManager customerManager1 = new CustomerManager(new Person());

              Company company = new Company();
              company.Id = 100;
              company.TaxNumber = "12340540";
              company.CompanyName = "Arçelik";

              Person person = new Person();
              person.Name = "Ümran";
              person.Surname = "Uğurlu";
              person.Nationalidentity = "1234567890";

              Customer c1 = new Customer();//referans tiptir
              Customer c2 = new Company();
              Customer c3 = new Person();
            **/

            CustomerManager customerManager = new CustomerManager(new Customer(), new CarCreditManager());
            customerManager.Save();
            customerManager.GiveCredit();
                
            Console.ReadLine();
        }
    }
    class CreditManager //operasyonlar, fonksiyonlar
    {
        public void Calculate() //methot
        {
            Console.WriteLine("Kredi hesaplandı.");
        }
        public void Save() //methot
        {
            Console.WriteLine("Kredi verildi.");
        }
    }
    //interface = (refarans tiptir.) genellikle iş yapan operasyonların (CreditManager,CustomerManager) sınıfların sadece imza seviyesinde yazarak yazılımda bağımlılığı korumak adına yapılan çalışmadır.
    interface ICreditManager
    {
        void Calculate();

        //DRY(do not repeat yourself) = Burada bulunan save methotu kendini tekrar eden bir methot.
        void Save();
    }
    abstract class BaseCreditManager : ICreditManager //abstract klaslarda tamamlanmış ve tamamlanmamış operasyon yazılabilir.
    {//abstract klaslar sınıf özelliği gösterir o yüzden bir sınıf bir abstract sınıfı inheritance edebilir.Bir sınıf sadece bir abstract klası yada başka bir class inheritance edebilir.
        //abstract classlar ve interface new lenemez referans tiplerin özelliklerinden yararlanır.
        public abstract void Calculate();//ortak değil her yerde değişken olduğu için sadece imza olarak bıraktık.
        //tamamlanmamış
        public void Save()//ortak hiç bir yerde değişmiyor. // tamamlanmış.
        {
            //hesaplamalar
            Console.WriteLine("Kaydedildi.");
        }
    }
    class CarCreditManager : BaseCreditManager, ICreditManager //araba kredisi klası ICreditManager interface inin operastonlarının, methotlarının içini doldurmak zorundadır.
    {
        public override void Calculate()//override üstüne yazmak
        {
            //hesaplamalar
            Console.WriteLine("Araba kredisi hesaplandı.");
        }

        //public void Save()
        //{
        //    //hesaplamalar
        //    Console.WriteLine("Kaydedildi.");
        //}
    }

    class HouseCreditManager : BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            //hesaplamalar
            Console.WriteLine("Ev kredisi hesaplandı.");
        }
        public virtual void Save()
        {
            //hesaplamalar
            Console.WriteLine("Ev kredisi kaydedildi.");
        }
    }
    class LandCreditManager : BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            //hesaplamalar
            Console.WriteLine("Arazi kredisi hesaplandı.");
        }
    }
    class Customer //özellikler //temel sınıf //içerisinde operasyonlar var
    {
        public Customer()//yapıcı methot
        {
            Console.WriteLine("Müşteri nesnesi başlatıldı.");
        }
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
    class Company : Customer //inheritance //kendi özellikleri olan ve temel sınıfı ve özellikleri, operasyonlarınıda kullanabilen bir sınıf
    {
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
    }
    class Person : Customer //inheritance //kendi özellikleri olan ve temel sınıfı ve özellikleri, operasyonlarınıda kullanabilen bir sınıf
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nationalidentity { get; set; }
    }
    class CustomerManager //encapsulation
    {
        private Customer _customer;
        private ICreditManager _creditManager;
        public CustomerManager(Customer customer, ICreditManager creditManager)//yapıcı methot
        {
            _customer = customer;
            _creditManager = creditManager;
        }
        public void Update()
        {
            Console.WriteLine("Müşteri güncellendi.");
        }
        public void Save()
        {
            Console.WriteLine("Müşteri kaydedildi : ");
        }
        public void Delete()
        {
            Console.WriteLine("Müşteri silindi : ");
        }
        public void GiveCredit()//(polymorphism = çok biçimlilik) örneğin burada bulunan GiveCredit e farklı biçimlerde davranış sergiletmiş oluyoruz.
        {
            _creditManager.Calculate();
            Console.WriteLine("Kredi verildi.");
        }
    }
}