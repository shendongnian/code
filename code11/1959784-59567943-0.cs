using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
public class Program
{			
	public static void Main()
	{
		    var tempPipeline = new List<BsonDocument>();
		
		    List<string> selectFields = new List<string>();
			selectFields.Add("<your requested field 1>");
			selectFields.Add("<your requested field 2>");
			
			var projection = new Dictionary<string, dynamic>();
		    //To include fields: Specify the field name and set to 0 in the project document.
		    //Ex:- Exclue _id field
            if (!selectFields.Contains("_id"))
            {
                projection.Add("_id", 0);
            }
		    //Only the fields specified in the project document are returned. The _id field is returned unless it is set to 0 in the Project document.
            //To include fields: Specify the field name and set to 1 in the project document.
		
		    foreach (var field in selectFields)
            {
                projection.Add(field, 1);		
				//or else
				//projection.Add(field, $"${field}");
            }
            var projectStage = new BsonDocument("$project", projection.ToBsonDocument());
		    tempPipeline.Add(projectStage.ToBsonDocument());
		
		    PipelineDefinition<BsonDocument, BsonDocument> aggregatonPipeline = tempPipeline;
            var cursor =  GetDatabase().GetCollection<BsonDocument>("<your collection>").Aggregate(aggregatonPipeline);
		
           IList<dynamic> results = new List<dynamic>();
            while (cursor.MoveNext())
            {
                foreach (var document in cursor.Current)
                {
                    results.Add(BsonSerializer.Deserialize<dynamic>(document));
                }
            }
            cursor.Dispose();
            results.ToList();
	}
	public static IMongoDatabase GetDatabase()
        {
            var settings = new MongoClientSettings
            {
                // setup your db settings
            };
            var client = new MongoClient(settings);
            return client.GetDatabase("<your database>");
	}
}
Read more to set which fields are returned: https://docs.mongodb.com/compass/master/query/project/
And more : 
https://docs.mongodb.com/manual/crud/
https://docs.mongodb.com/manual/tutorial/query-documents/
