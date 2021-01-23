    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;
    namespace Bookstore
    {
        public class User
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
        [Table("UsersFull")]
        public class UserFull : User
        {
            public string Street { get; set; }
            public string Country { get; set; }
        }
        public class Context : DbContext
        {
            static Context()
            {
                Database.SetInitializer<Context>(null);
            }
            public DbSet<User> Users { get; set; }
            public DbSet<UserFull> UsersFull { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var context = new Context();
                context.Database.Delete();
                context.Database.Create();
                var userFull = new UserFull { Country = "Alabama", FirstName = "John", LastName = "Capioca", Street = "astreetname" };
                context.UsersFull.Add(userFull);
                context.SaveChanges();
                var theUserToMatch = (from r in context.UsersFull
                                      where r.Street.ToLower() == "astreetname"
                                      select r);
                if (theUserToMatch.Count() != 0)
                    Console.WriteLine("Yeah! No Invalid column name 'Discriminator' exception");
                Console.ReadLine();
            }
        }
    }
