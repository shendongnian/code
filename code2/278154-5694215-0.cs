    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.Linq.Mapping;
    namespace ConsoleApplication2
    {
        class Person
        {
            public int Id;
            public string Name;
            public DateTime BirthDate;
        }
        class Program
        {
            public static U GetPropertyColumn<T,U>(T Param, Func<T,U> Lambda)
            {
                return Lambda(Param);
            }
            static void Main(string[] args)
            {
                Person test = new Person();
                test.Id = 35;
                test.Name = "Some text here";
                test.BirthDate = DateTime.Now;
                Console.WriteLine(GetPropertyColumn<Person, string>(test, e => e.Name));
            }
        }
    }
