    var user= JsonConvert.DeserializeObject<User>(yourJson);
    user.Tokens.Add(new Token());
    var _users = db.GetCollection<Users>("Users"); // if you have this initialized before re-use it
    var filter = Builders<User>.Filter.Eq(s => s.Id, user.Id);
    var result = await collection.ReplaceOneAsync(filter, user)
