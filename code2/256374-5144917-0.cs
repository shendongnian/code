    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                //lets say this is the list that you have you mah have more fields
                List<Person> people = new List<Person>();
                people.Add(new Person(25, "Jhon"));
                people.Add(new Person(22, "Antonio"));
                people.Add(new Person(21, "Waid"));
                people.Add(new Person(21, "Chris"));
                people.Add(new Person(26, "Lacy"));
                people.Add(new Person(21, "Albert"));
                people.Add(new Person(45, "Tom"));
                people.Add(new Person(65, "Bob"));
           
                var query = from a in people   // crate a query from your list in this case the list is people
                            where a.age > 18 && a.age < 50  // select just people that has an age greater than 0 and less than 100
                                                            // maybe you want to filter some results if you dont then delete this line.
                            orderby a.name                  // order the results by their name
                            select a.name;                  // then select just the name. if you type select just a then query will 
                                                            // contain a list of ages too.
                // loop though the results to see if they were ordered
                foreach (string name in query)
                {
                    Console.WriteLine(name);
                }            
                Console.Read();
            }
        }
        // I created this class because I dont know what your list contains I know it has a string therefore I added a string
        // you may add more properties and it will still work...
        class Person
        {
            public int age;
            public string name;
            public Person(int a, string n)
            {
                age = a;
                name = n;
            }
        }
    }
