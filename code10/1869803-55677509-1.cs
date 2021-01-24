    var root = new Documents();
    root.Documents = new List<Document>
    {
        new Document
        {
            Index = ""index-name-test", 
            Type = "doc", 
            Id = g.ToString(),
            Title = "title1",
            Timestamp = DateTime.UtcNow
        }
    };
    var json = JsonConvert.SerializeObject(root);
