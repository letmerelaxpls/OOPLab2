using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2
{
    //1 задача
    public class Address
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Apartment { get; set; }
        public string Index { get; set; }
    }
    public class Converter
    {
        public double USD { get; }
        public double EUR { get; }
        public double RUB { get; }

        public Converter(double usd, double eur, double rub)
        {
            USD = usd;
            EUR = eur;
            RUB = rub;
        }

        public double ConvertToUsd(double value)
        {
            return value / USD;
        }

        public double ConvertToEur(double value)
        {
            return value / EUR;
        }

        public double ConvertToRub(double value)
        {
            return value / RUB;
        }

        public double ConvertFromUsd(double value)
        {
            return USD * value;
        }

        public double ConvertFromEur(double value)
        {
            return EUR * value;
        }
        public double ConvertFromRub(double value)
        {
            return RUB * value;
        }
    }
    class Employee
    {
        public string name;
        public string surname;
        public static string dateOfHire;
        public OperateCost operationCost;


        public Employee(string name, string surname, string dateOfHire, OperateCost opCost)
        {
            this.name = name;
            this.surname = surname;
            Employee.dateOfHire = dateOfHire;
            this.operationCost = opCost;

        }

        public static double DiscoverGrade(string dateOfHire)
        {
            double dateValueForGrade = (DateTime.Now - DateTime.Parse(dateOfHire)).TotalDays;

            if (dateValueForGrade >= 1825 && dateValueForGrade < 3650)
                return 1.1;
            else if (dateValueForGrade >= 3650)
                return 1.3;
            else
                return 1;
        }
    }
    abstract class OperateCost
    {
        public double salary;
        public double tax;

        public abstract void ApplyBonus(double grade);
        public abstract void ApplyTax();
    }

    class Slave : OperateCost
    {
        public override void ApplyBonus(double grade)
        {
            salary = 15000 * grade;
        }

        public override void ApplyTax()
        {
            tax = salary * 0.27;
        }
    }

    class Smesharik : OperateCost
    {
        public override void ApplyBonus(double grade)
        {
            salary = 26000 * grade;
        }
        public override void ApplyTax()
        {
            tax = salary * 0.27;
        }
    }

    class Master : OperateCost
    {
        public override void ApplyBonus(double grade)
        {
            salary = 99999 * grade;
        }
        public override void ApplyTax()
        {
            tax = salary * 0.27;
        }
    }
    class User
    {
        string userLogin, userName, userSurname;
        int age;
        public readonly DateTime date;
        public string Login        
        {
            set { userLogin = value; }
            get
            {
                if (userLogin == null)
                    return "Ошибка: Поле не заполнено";
                return userLogin;
            }
        }
        public string Name   
        {
            set { userName = value; }
            get
            {
                if (userName == null)
                    return "Ошибка: Поле не заполнено";
                return userName;
            }
        }
        public string Surname   
        {
            set { userSurname = value; }
            get
            {
                if (userSurname == null)
                    return "Ошибка: Поле не заполнено";
                return userSurname;
            }
        }
        public int Age         
        {
            set { age = value; }
            get
            {
                if (age <= 0)
                    return 18;
                return age;
            }
        }
        public User()
        {
            date = DateTime.Now;    
        }
        public User(string login, string name, string surname, int age)
        {
            this.Login = login;
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            date = DateTime.Now;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите задачу (цифру): ");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Address address = new Address();

            address.Country = "Украина";
            address.City = "Киев";
            address.Street = "Лобачевского";
            address.House = "23";
            address.Apartment = "827";
            address.Index = "12345";

            Console.WriteLine("Страна: " + address.Country);
            Console.WriteLine("Город: " + address.City);
            Console.WriteLine("Улица: " + address.Street);
            Console.WriteLine("Дом: " + address.House);
            Console.WriteLine("Квартира: " + address.Apartment);
            Console.WriteLine("Индекс: " + address.Index);
                    break;
                case 2:

            var currencyconverter = new Converter(36.9, 36.7, 0.61);
            Console.WriteLine("Выберите опцию: ");
            Console.WriteLine("1: Конвертировать в гривну");
            Console.WriteLine("2: Конвертировать из гривны");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    ConvertTo(currencyconverter);
                    break;
                case 2:
                    ConvertFrom(currencyconverter);
                    break;
            }
            Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("Имя: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Фамилия: ");
                    string surname = Console.ReadLine();
                    Console.WriteLine("Дата найма: ");
                    string dateOfHire = Console.ReadLine();

                    OperateCost oc = new Smesharik();
                    Employee emp = new Employee(name, surname, dateOfHire, oc);
                    double grade = Employee.DiscoverGrade("15.03.2002");
                    Console.WriteLine("Имя: {0}, Фамилия: {1}, Дата найма: {2}, Должность: {3}", emp.name, emp.surname, Employee.dateOfHire, emp.operationCost);
                    oc.ApplyBonus(grade);
                    oc.ApplyTax();
                    Console.WriteLine("Зарплата: {0}, Налог: {1}", emp.operationCost.salary, emp.operationCost.tax);
                    Console.ReadKey();
                    break;
                case 4:
                    User xxx = new User();
                    Console.WriteLine("Введите логин:");
                    xxx.Login = Console.ReadLine();
                    Console.WriteLine("Введите Имя:");
                    xxx.Name = Console.ReadLine();
                    Console.WriteLine("Введите Фамилию:");
                    xxx.Surname = Console.ReadLine();
                    Console.WriteLine("Введите возраст:");
                    xxx.Age = int.Parse(Console.ReadLine());

                    Console.WriteLine("Информация о пользователе: Логин: {0}, Имя: {1}, Фамилия: {2}, Возраст: {3}, Время: {4}", xxx.Login, xxx.Name, xxx.Surname, xxx.Age, DateTime.Now);

                    //Delay
                    Console.ReadKey();
                    break;
            }
        }
        private static void ConvertTo(Converter converter)
        {
            Console.WriteLine("Выберите опцию: ");
            Console.WriteLine("1: Конвертировать из USD");
            Console.WriteLine("2: Конвертировать из EUR");
            Console.WriteLine("3: Конвертировать из RUB");
            var option = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите кол-во");
            var input = double.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.WriteLine(converter.ConvertFromUsd(input));
                    break;
                case 2:
                    Console.WriteLine(converter.ConvertFromEur(input));
                    break;
                case 3:
                    Console.WriteLine(converter.ConvertFromRub(input));
                    break;
            }
        }
        private static void ConvertFrom(Converter converter)
        {
            Console.WriteLine("Выберите опцию: ");
            Console.WriteLine("1: Конвертировать в USD");
            Console.WriteLine("2: Конвертировать в EUR");
            Console.WriteLine("2: Конвертировать в RUB");
            var option = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите кол-во");

            var input = double.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine(converter.ConvertToUsd(input));
                    break;
                case 2:
                    Console.WriteLine(converter.ConvertToEur(input));
                    break;
                case 3:
                    Console.WriteLine(converter.ConvertToRub(input));
                    break;
            }
        }
    }
}
//2 задача



