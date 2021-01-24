csharp
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
namespace StackOverflow
{
    public class Program
    {
        public class Metadata
        {
            public string Beloeb { get; set; }
            public string Overskrift { get; set; }
            public string Gruppe { get; set; }
            public string Beskrivelse { get; set; }
            public string Dato { get; set; }
            public string Afsender { get; set; }
        }
        public class RootObject
        {
            [BsonId] // need to add this
            public ObjectId ID { get; set; }
            public int length { get; set; }
            public double chunkSize { get; set; }
            public DateTime uploadDate { get; set; }
            public string md5 { get; set; }
            public string filename { get; set; }
            public Metadata metadata { get; set; }
        }
        private static void Main(string[] args)
        {
            var collection = new MongoClient("mongodb://localhost")
                                    .GetDatabase("test")
                                    .GetCollection<RootObject>("fs.files");
            var result = collection.Find(Builders<RootObject>.Filter.Empty).ToList();
            foreach (var doc in result)
            {
                Console.WriteLine(doc.ToJson());
                Console.WriteLine("");
                Console.WriteLine(doc.ID.ToString());
                Console.Read();
            }
        }
    }
}
`
