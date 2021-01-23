    List<Question> list = new List<Question>();
    MongoServer _server = MongoServer.Create("mongodb://localhost");
    MongoDatabase _database = _server.GetDatabase("test");
    var query = Query.And(Query.EQ("AnswerChoices._id", new ObjectId("4d6d336ae0f84c23bc1fae00")));
    MongoCollection<Question> collection = _database.GetCollection<Question>("Question");
    MongoCursor<Question> cursor = collection.Find(query);
    
    var id = new ObjectId("4d6d336ae0f84c23bc1fae00");
    foreach (var q in cursor)
    {
        var answerChoice = q.AnswerChoices.Single(x=> x.AnswerChoiceId == id);
        list.Add(q);
    }
