    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    namespace JsonToObjectTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var children = new List<Person>()
                {
                    new Person("Michael", "Puckett III", new DateTime(2000, 07, 25), null),
                    new Person("Samuel", "Puckett", new DateTime(2003, 07, 23), null),
                    new Person("Haylee", "Sanders", new DateTime(2004, 01, 05), null)
                };
    
                var dad = new Person("Michael", "Puckett II", new DateTime(1980, 01, 29), children);
    
                var json = JsonConvert.SerializeObject(dad);
    
                Console.WriteLine(json); //dad with array of children is converted to a json string here
    
                var jsonDad = JsonConvert.DeserializeObject<Person>(json); //json string is converted to Person object here
    
                Console.WriteLine($"Name: {jsonDad.FirstName} {jsonDad.LastName}\nDOB: {jsonDad.DOB.ToString()}");
    
                foreach (var child in jsonDad.Children)
                {
                    Console.WriteLine($"Name: {child.FirstName} {child.LastName}\nDOB: {child.DOB.ToString()}");
                }
    
                Console.Read();
            }
    
            public class Person
            {
                public Person(string firstName, string lastName, DateTime dob, List<Person> children)
                {
                    FirstName = firstName;
                    LastName = lastName;
                    DOB = dob;
                    Children = children;
                }
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public DateTime DOB { get; set; }
                public List<Person> Children { get; set; }
            }
        }
    }
