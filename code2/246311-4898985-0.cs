    using (var db = new News.Data.Entities("name=NewsEntities"))
    {
        results1 = db.News.ToList();
    }
    
    using (var db = new Tag.Data.Entities("name=TagEntities"))
    {
        results2 = db.Tag.ToList();
    }
