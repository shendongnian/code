using System;
using System.Linq;
using MongoDAL;
namespace Example
{
    class Client : Entity
    {
        public string Name { get; set; }
        public Asset[] Assets { get; set; }
    }
    class Asset
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            new DB("assets");
            var client = new Client
            {
                Name = "Marco Polo",
                Assets = new Asset[]
                 {
                     new Asset{ Name = "asset one", Enabled = true},
                     new Asset{ Name = "asset two", Enabled = true},
                     new Asset{ Name = "asset three", Enabled = true}
                 }
            };
            client.Save();
            var clientID = client.ID;
            var result = client.Collection()
                               .Where(c => c.ID == clientID)
                               .SelectMany(c => c.Assets)
                               .ToArray();
            Console.ReadKey();
        }
    }
}
generated mongo query:
aggregate([{ 
"$match" : { "_id" : ObjectId("5cc0643744effe2fa482648e") } },
{ "$unwind" : "$Assets" },
{ "$project" : 
{ "Assets" : "$Assets", "_id" : 0 } }])
