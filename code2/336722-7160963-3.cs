    using System.Linq;
    class Person
    {
        public int Id; 
        public string Name;
    }
    class Address
    {
        public int Id;
        public string Street;
    }
    class PersonAddress
    {
        public int PersonId, AddressId;
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var personList = new []
            {
                new Person { Id = 1, Name = "Pete" },
                new Person { Id = 2, Name = "Mary" },
                new Person { Id = 3, Name = "Joe" }
            };
            var addressList = new []
            {
                new Address { Id = 100, Street = "Home Lane" },
                new Address { Id = 101, Street = "Church Way" },
                new Address { Id = 102, Street = "Sandy Blvd" }
            };
            var relations = new [] 
            {
                new PersonAddress { PersonId = 1, AddressId = 101 },
                new PersonAddress { PersonId = 3, AddressId = 101 },
                new PersonAddress { PersonId = 2, AddressId = 102 },
                new PersonAddress { PersonId = 2, AddressId = 100 }
            };
            var joined = from p in personList
                         join par in relations
                             on p.Id equals par.PersonId
                         join a in addressList
                             on a.Id equals par.AddressId
                    select new { p.Name, a.Street };
            foreach (var record in joined)
                System.Console.WriteLine("{0} lives on {1}", record.Name, record.Street);
        }
    }
