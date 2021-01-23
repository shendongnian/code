    using System;
    
    class Person
    {
        public string Name { get; set; }
    }
    
    class Test
    {
        static void Main(string[] arg)
        {
            Person p = new Person();
            var property = typeof(Person).GetProperty("Name");
            property.SetValue(p, "Jon", null);
            Console.WriteLine(p.Name); // Jon
        }
    }
