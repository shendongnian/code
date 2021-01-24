csharp
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
namespace StackOverflow
{
    public class ClientProject
    {
        public ObjectId _id { get; set; }
        public DateTime StartedWithPoOn { get; set; }
        public ObjectId PartnerId { get; set; }
        [BsonRepresentation(BsonType.String)]
        public int Status { get; set; }
        [BsonRepresentation(BsonType.String)]
        public int ProjectType { get; set; }
        public Bundle Bundle { get; set; }
    }
    public class Bundle
    {
        public ObjectId _id { get; set; }
        public List<Variations> Variations { get; set; }
    }
    public class Variations
    {
        public ObjectId _id { get; set; }
        public string Code { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string VariationType { get; set; }
        public Assets[] Assets { get; set; }
        public string Summary { get; set; }
    }
    public class Assets
    {
        public string Asset { get; set; }
        public string Price { get; set; }
        public bool CanBeExcluded { get; set; }
    }
    public class Program
    {
        private static void Main(string[] args)
        {
            var coll = new MongoClient("mongodb://localhost")
                            .GetDatabase("test")
                            .GetCollection<ClientProject>("ClientProject");
            var result = coll.AsQueryable()
                             .Where(xx =>
                                    xx.Status >= 7 &&
                                    xx.PartnerId != null &&
                                    xx.ProjectType == 0 &&
                                    xx.StartedWithPoOn >= new DateTime(2019, 09, 25) &&
                                    xx.StartedWithPoOn <= new DateTime(2019, 09, 29) &&
                                    xx.Bundle.Variations[0].Assets.Any(yy => yy.Asset == "ST_MT_1040_N"))
                             .ToList();
        }
    }
}
