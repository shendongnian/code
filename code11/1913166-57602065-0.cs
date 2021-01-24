csharp
using MongoDB.Entities;
using System.Linq;
namespace StackOverflow
{
    public class RootDoc : Entity
    {
        public Person[] PersonInventory { get; set; }
    }
    public class Person
    {
        public long PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class Program
    {
        private static void Main(string[] args)
        {
            new DB("test");
            (new[] {
                new RootDoc{
                    PersonInventory = new[]{
                        new Person{ PersonId = 1, FirstName = "first", LastName="person"},
                        new Person{PersonId = 2, FirstName = "second", LastName="person"}
                    }
                },
                new RootDoc{
                    PersonInventory = new[]{
                        new Person { PersonId = 2, FirstName = "second", LastName = "person" } }
                }
            }).Save();
            var uniquePersons = DB.Queryable<RootDoc>()
                                  .Where(r => r.PersonInventory.Any())
                                  .SelectMany(r => r.PersonInventory)
                                  .Distinct()
                                  .ToArray();
        }
    }
}
above code uses my library [MongoDB.Entities](https://www.nuget.org/packages/MongoDB.Entities) for brevity. just replace `DB.Queryable<RootDoc>()` with `collection.AsQueryable()` for official driver.
