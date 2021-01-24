        protected  void Page_Load(object sender, EventArgs e)
    {
        // //BsonDocument modal = new BsonDocument;
        string id = "e0b4a7b7-096a-4a8a-b942-83fccf81e6c5";
        var client = new MongoClient(mongocon);
        var db = client.GetDatabase("Mydb");
        var collection = db.GetCollection<dynamic>("new");
        var filter = Builders<dynamic>.Filter.Eq("_id", id); //filter the bson document based on ID
    
        // var list = collection.Find(filter).ToList();
        //var filterx = new BsonDocument("_id", "e0b4a7b7-096a-4a8a-b942-83fccf81e6c5");
    
        var result = collection.Find(filter).ToList();
    
    
        GridView1.DataSource = result;
        GridView1.DataBind();
