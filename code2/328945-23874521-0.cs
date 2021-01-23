    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Person
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public int SomeValue { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> data = GetPopulatedData();
            var totals = data.GroupBy(x =>
                new { x.Name, x.City, x.ZipCode }).Select(y =>
                    y.Sum(i => i.SomeValue));
            var groupsForIterate = data.GroupBy(x =>
                new { x.Name, x.City, x.ZipCode });
            Console.WriteLine("Totals: ");
            foreach (var total in totals)
            {
                Console.WriteLine(total);
            }
            Console.WriteLine("Categories: ");
            foreach (var categ in groupsForIterate)
            {
                // You can refer to one field like this: categ.Key.Ciduad
                Console.WriteLine("Group" + categ.Key);
                Console.WriteLine(categ.Sum(x => x.SomeValue));
            }
            //Output:
            //Totals:
            //1
            //2
            //1
            //Categories:
            //Group{ Name = Mark, City = BCN, ZipCode = 00000 }
            //1
            //Group{ Name = Mark, City = BCN, ZipCode = 000000 }
            //2
            //Group{ Name = John, City = NYC, ZipCode = 000000 }
            //1
        }
        private static List<Person> GetPopulatedData()
        {
            List<Person> datos = new List<Person>()
            {
                new Person(){Name="Mark", City = "BCN",
                    ZipCode = "00000", SomeValue = 1}, // group A
                new Person(){Name="Mark", City = "BCN",
                    ZipCode = "000000", SomeValue = 1}, // group B
                new Person(){Name="Mark", City = "BCN",
                    ZipCode = "000000", SomeValue = 1}, // group B
                new Person(){Name="John", City = "NYC",
                    ZipCode = "000000", SomeValue = 1}, // group C
            };
            return datos;
        }
    }
