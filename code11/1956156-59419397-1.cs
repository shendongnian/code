    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson.Serialization.Options;
    using MongoDB.Entities;
    using MongoDB.Entities.Core;
    using System.Collections.Generic;
    using System.Linq;
    namespace StackOverflow
    {
        public class User : Entity
        {
            [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfDocuments)]
            public Dictionary<ObjectId, int> DeviceActions { get; set; } = new Dictionary<ObjectId, int>();
        }
        internal class Program
        {
            private static void Main()
            {
                new DB("test", "localhost");
                var user = new User();
                user.DeviceActions.Add(ObjectId.GenerateNewId(), 100);
                user.DeviceActions.Add(ObjectId.GenerateNewId(), 200);
                user.DeviceActions.Add(ObjectId.GenerateNewId(), 300);
                user.Save();
                var userID = user.ID;
                var key = user.DeviceActions.First().Key;
                DB.Update<User>()
                  .Match(u =>
                         u.ID == userID &
                         u.DeviceActions.Any(a => a.Key == key))
                  .Modify(b => b.Set("DeviceActions.$.v", 0))
                  .Execute();
            }
        }
    }
