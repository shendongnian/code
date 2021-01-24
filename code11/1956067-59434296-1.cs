    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Entities;
    using MongoDB.Entities.Core;
    using System.Collections.Generic;
    using System.Linq;
    namespace StackOverflow
    {
        public class GameTransactions : Entity
        {
            [BsonRepresentation(BsonType.ObjectId)]
            public string UserId { get; set; }
            public List<UplinePt> UplinePts { get; set; }
        }
        public class UplinePt
        {
            public string UserId { get; set; }
            public decimal Percentage { get; set; }
        }
        public class Users : Entity
        {
            public string LoginId { get; set; }
            public string Name { get; set; }
        }
        internal class Program
        {
            private static void Main()
            {
                new DB("test", "localhost");
                var userOne = new Users { Name = "one", LoginId = "adam" };
                userOne.Save();
                var userTwo = new Users { Name = "two", LoginId = "bandwagon" };
                userTwo.Save();
                (new[] {
                  new GameTransactions{
                      UserId = userOne.ID,
                      UplinePts = new List<UplinePt> {
                          new UplinePt { UserId = userOne.ID, Percentage = 10.1m },
                          new UplinePt { UserId = userOne.ID, Percentage = 20.2m }}
                  },
                  new GameTransactions{
                      UserId = userTwo.ID,
                      UplinePts = new List<UplinePt> {
                          new UplinePt { UserId = userTwo.ID, Percentage = 30.3m },
                          new UplinePt { UserId = userTwo.ID, Percentage = 40.4m }}
                  }
                }).Save();
                var transactions = DB.Queryable<Users>()
                                     .Where(u => u.LoginId.Contains("a"))
                                     .Join(
                                        DB.Queryable<GameTransactions>(),
                                        u => u.ID,
                                        t => t.UserId,
                                        (u, t) => t)
                                     .ToList();
            }
        }
    }
