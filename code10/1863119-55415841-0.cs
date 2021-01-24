    var messages = db.GetCollection<MessageExchange>(collectionName);
    var ids = messages
       .AsQueryable()
       .Where(_=> true)
       .Select(x => x.Id.ToString())
       .ToList();
