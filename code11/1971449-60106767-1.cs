    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Entities;
    using MongoDB.Entities.Core;
    namespace StackOverFlow
    {
        public enum Status { Good, Bad }
        public class Document : Entity
        {
            [BsonRepresentation(BsonType.String)]
            public Status Status { get; set; }
        }
        public static class Program
        {
            private static void Main()
            {
                new DB("test");
                new Document { Status = Status.Bad }.Save();
                var statusValue = Status.Good;
                DB.Update<Document>()
                  .Match(f => f.Eq(d => d.Status, Status.Bad))
                  .Modify(b => b.Set(d => d.Status, statusValue))
                  .Execute();
            }
        }
    }
