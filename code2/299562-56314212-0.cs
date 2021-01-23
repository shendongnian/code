csharp
using System;
using MongoDB.Driver;
using MongoDB.Entities;
namespace StackOverflow
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            new DB("test");
            DB.Index<User>()
              .Options(o => o.Unique = true, o => o.Background = false)
              .Key(u => u.EmailAddress, Type.Ascending)
              .Create();
            var user1 = new User { Name = "First User", EmailAddress = "email@domain.com" };
            user1.Save();
            try
            {
                var user2 = new User { Name = "Second User", EmailAddress = "email@domain.com" };
                user2.Save();
            }
            catch (MongoWriteException x)
            {
                Console.WriteLine(x.Message);
                Console.ReadKey();
            }
        }
    }
}
trying to create a second user with the same email address results in the following exception:
A write operation resulted in an error. E11000 duplicate key error collection: test.User index: EmailAddress(Asc) dup key: { : "email@domain.com" }
