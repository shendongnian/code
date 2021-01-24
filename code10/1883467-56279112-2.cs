    using System;
    namespace Program1
    {
        static void Main(string[] args)
        {
             string name;
             int age;
             int yearsTillRetire;
             Console.WriteLine("Please enter your name..")
             name = Console.ReadLine();
             Console.WriteLine("Please enter your age..")
             age = Convert.ToInt32(Console.ReadLine());
             yearsTillRetire = YearsToWork(age);
             Console.WriteLine("----------------------------------------");
             Console.WriteLine($"Hello, {0}. Looks like you have {1} years left for work",  name, yearsTillRetire);
             Console.ReadLine();
        }
        public int YearsToWork (int age)
        {
            if (age < 65) return (65 - age);
            /*you could also probably throw some condition in here to check if 
              they're over 65 as well*/
        }
    }
