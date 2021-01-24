    using MongoDB.Bson;
    using MongoDB.Entities;
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
                  .Modify(b => b.PullFilter(u => u.User.Contacts, c => c._Id == contactID))
                  .Execute();
            }
        }
    }
