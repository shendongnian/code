csharp
using MongoDB.Entities;
using System;
using System.Linq;
namespace StackOverflow
{
    public class Program
    {
        public class Book : Entity
        {
            public string Title { get; set; }
            public Author Author { get; set; }
        }
        public class Author
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
        
        private static void Main(string[] args)
        {
            new DB("test");
            (new Book
            {
                Title = "a book title goes here",
                Author = new Author
                {
                    FirstName = "First Name",
                    LastName = "Last Name"
                }
            }).Save();
            var res = DB.Queryable<Book>()
                        .Select(b => new
                        {
                            Title = b.Title,
                            LastName = b.Author.LastName
                        }).ToArray();
            foreach (var b in res)
            {
                Console.WriteLine($"title: {b.Title} / lastname: {b.LastName}");
            }
            Console.Read();
        }
    }
}
the above code is using my library [MongoDB.Entities](https://github.com/dj-nitehawk/MongoDB.Entities) for brevity. simply replace `DB.Queryable<Book>()` with `collection.AsQueryable()` for the official driver.
