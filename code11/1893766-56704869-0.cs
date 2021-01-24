        //Build an Id Filter
        var idFilter = Builders<Chat>.Filter.Eq(x => x.Id, "1");
      
        var message = new Message() { MessageContent = "Hey!", Method = "Slack" };
        //Build an update definition to add the message
        var addMessage = Builders<Chat>.Update.AddToSet(x => x.Messages, message);
        //Build an update definition to set the LastSent property
        var setLastSent = Builders<Chat>.Update.Set(x => x.LastSent, DateTime.Now);
        //Combine both update definitions
        var combinedUpdate = Builders<Chat>.Update.Combine(addMessage, setLastSent);
        //Execute the query.
        db.GetCollection<Chat>("ChatCollection").UpdateOne(idFilter, combinedUpdate);
