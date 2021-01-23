    var server = MongoServer.Create("mongodb://localhost");
    var db = server.GetDatabase("myapp");
    
    var users = db.GetCollection<User>("users");
    
    users.EnsureIndex(new IndexKeysBuilder()
        .Ascending("EmailAddress"), IndexOptions.SetUnique(true));
    
    var user1 = new User { EmailAddress = "joe@example.com" };
    var user2 = new User { EmailAddress = "joe@example.com" };
    
    try
    {
        users.Save(user1, SafeMode.True);
        users.Save(user2, SafeMode.True);  // <-- throws MongoSafeModeException
    }
    catch (MongoSafeModeException ex)
    {
        Console.WriteLine(ex.Message);
    }
