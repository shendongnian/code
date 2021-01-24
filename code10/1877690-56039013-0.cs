using System.Linq;
using MongoDB.Entities;
namespace Library
{
    public class Author : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class Book : Entity
    {
        public string Title { get; set; }
        public One<Author> MainAuthor { get; set; } // one-to-one relationship
    }
    class Program
    {
        static void Main(string[] args)
        {
            new DB("library");
            var author1 = new Author
            {
                FirstName = "Eckhart",
                LastName = "Tolle"
            };
            author1.Save();
            var book1 = new Book
            {
                Title = "The Power Of Now",
                MainAuthor = author1.ToReference()
            };
            book1.Save();
            var powerOfNow = DB.Collection<Book>()
                               .Where(b => b.Title.Contains("Now"))
                               .FirstOrDefault();
            var eckhartTolle = powerOfNow.MainAuthor.ToEntity();
        }
    }
}
