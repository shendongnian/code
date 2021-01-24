using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Linq;
public string MaxLsNr<T>(string cl, string prefix) //collection and prefix 'L'
{
    string bsonQuery = "{'LsNr': {$regex: '" + prefix + "'}}"; //filter by prefix
    var filter = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(bsonQuery);
    var collection = db.GetCollection<BsonDocument>(cl);
    var data = collection.Find(filter).ToList();
    
    // Get the max number from the results.
    int max = data.Max(x => int.Parse(string.IsNullOrEmpty(x["LsNr"].ToString().Substring(1)) ? "0" : x["LsNr"].ToString().Substring(1)));
    // Get the single record based on Prefix and Max number.
    var result = data.FirstOrDefault(x => x["LsNr"].Equals($"{prefix}{max == 0 ? "" : max}");
    // other code here...
}
