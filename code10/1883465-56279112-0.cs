    using System;
    namespace Program1
    {
        static void Main(string[] args)
        {
             var person = new Person();
             int yearsTillRetire;
             Console.WriteLine("Please enter your name..")
             person.Name = Console.ReadLine();
             Console.WriteLine("Please enter your age..")
             person.Age = Convert.ToInt32(Console.ReadLine());
             yearsTillRetire = YearsToWork(person.Age);
             Console.WriteLine("----------------------------------------");
             Console.WriteLine("Hello, {1}. Looks like you have {0} years left for work", yearsTillRetire, person.Name);
             Console.ReadLine();
        }
        public class Person
        {
            public string Name {get; set;}
            public int Age {get; set;}
        }
        public int YearsToWork (int age)
        {
            if (age < 65) return (65 - age);
            /*you could also probably throw some condition in here to check if they're 
            over 65 as well*/
        }
    }
