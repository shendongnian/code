    using System;
    using System.Collections;
    using System.Collections.ObjectModel;
    
    namespace ShowNames
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
                var People = new Collection<Person>()
                {
                    new Person() { Name = "Jack", Age = 24, AverageGrade = 7.23 },
                    new Person() { Name = "Jessica",  Age = 29,   AverageGrade = 8.12 },
                    new Person() { Name = "Joe", Age = 25, AverageGrade = 9.51 },
                };
    
                foreach (var PersonItem in People)
                {
                    Console.WriteLine("Name = {0}", PersonItem.Name);
                }
    
            }
    
        }
    
        internal class Person
        {
            public string Name;
            public decimal Age;
            public double AverageGrade;
        }
    }
