using System;
using System.Linq;
using MongoDAL;
namespace Example
{
    class Person : Entity
    {
        public string Name { get; set; }
    }
    class BanRecord : Entity
    {
        public One<Person> Person { get; set; }
        public string ReasonForBan { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            new DB("testdatabase");
            var person1 = new Person { Name = "Person One" };
            var person2 = new Person { Name = "Person Two" };
            var person3 = new Person { Name = "Person Three" };
            person1.Save();
            person2.Save();
            person3.Save();
            var ban1 = new BanRecord
            {
                Person = person1.ToReference(),
                ReasonForBan = "Cause we can!"
            };
            ban1.Save();
            var ban2 = new BanRecord
            {
                Person = person2.ToReference(),
                ReasonForBan = "Cause we can!"
            };
            ban2.Save();
            var bannedPeople = (from b in DB.Collection<BanRecord>()
                                join p in DB.Collection<Person>() on b.Person.ID equals p.ID into banned
                                from p in banned
                                select p).ToArray();
            Console.ReadKey();
        }
    }
}
