    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    namespace TestEnsureIndexOnEmailAddress {
        public class User {
            public ObjectId Id;
            public string FirstName;
            public string LastName;
            public string EmailAddress;
        }
        public static class Program {
            public static void Main(string[] args) {
                var server = MongoServer.Create("mongodb://localhost/?safe=true");
                var database = server["test"];
                var users = database.GetCollection<User>("users");
                if (users.Exists()) { users.Drop(); }
                users.EnsureIndex(IndexKeys.Ascending("EmailAddress"), IndexOptions.SetUnique(true));
                var john = new User { FirstName = "John", LastName = "Smith", EmailAddress = "jsmith@xyz.com" };
                users.Insert(john);
                var joe = new User { FirstName = "Joe", LastName = "Smith", EmailAddress = "jsmith@xyz.com" };
                users.Insert(joe); // should throw exception
            }
        }
    }
