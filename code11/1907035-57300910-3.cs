    using MongoDB.Entities; // PM> Install-Package MongoDB.Entities
    using MongoDB.Bson;    
    using System.Linq;
    namespace StackOverflow
    {
        public class Program
        {
            public class UserCollection : Entity
            {
                public User User { get; set; }
            }
            public class User
            {
                public Contact[] Contacts { get; set; }
            }
            public class Contact
            {
                public ObjectId _Id { get; set; }
            }
            private static void Main(string[] args)
            {
                new DB("test");
                var contactID = ObjectId.GenerateNewId();
                (new UserCollection
                {
                    User = new User
                    {
                        Contacts = new[]
                        {
                            new Contact { _Id = ObjectId.GenerateNewId()},
                            new Contact { _Id = contactID}
                        }
                    }
                }).Save();
                DB.Update<UserCollection>()
                  .Match(u => u.User.Contacts.Any(c => c._Id == contactID))
                  .Modify(b => b.PullFilter(u => u.User.Contacts, c => c._Id == contactID))
                  .Execute();
            }
        }
    }
