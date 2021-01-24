    public class Models
    {
        public int _id { get; set; }
        public string ModelType { get; set; }
        public List<ModelList> ModelList { get; set; } = new List<ModelList>();
    }
    public class ModelList
    {
        public string ModelHashKey { get; set; }
        public string ModelName { get; set; }
        public string ModelAttribute { get; set; }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new MongoClient();
            var db = client.GetDatabase("test");
            var collection = db.GetCollection<Models>("models");
            var models = collection.Aggregate()
                .Match(Builders<Models>.Filter.Eq(x => x.ModelType, "Player") & Builders<Models>.Filter.ElemMatch(x => x.ModelList, Builders<ModelList>.Filter.Eq(x => x.ModelAttribute, "Male")))
                .AppendStage<Models>(BsonDocument.Parse(@"{ $addFields: { ""ModelList"" : { $filter: { input: ""$ModelList"", as: ""item"", cond: { $eq: [""$$item.ModelAttribute"", ""Male""] } } } } }"))
                .ToList();
            foreach (var model in models)
            {
                foreach (var item in model.ModelList)
                {
                    Console.WriteLine(item.ToJson());
                }
            }
        }
    }
	
