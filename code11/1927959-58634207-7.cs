    var authors = bookEntities.GroupBy(c => c.ParentId, c => c,
        (key, books) => new DbAuthor()
        {
            Id = key,
            Books = books.ToList(),
            LastName = collection.Find(c => c.Id == key).FirstOrDefault().LastName,
            LifeExpectancy = collection.Find(c => c.Id == key).FirstOrDefault().LifeExpectancy
        });
    
    await authors.ToAsyncEnumerable().ForEachAsync(async c => await collection.UpdateOneAsync(
        p => p.Id == c.Id,
        Builders<DbAuthor>.Update.Combine(
            Builders<Author>.Update.AddToSetEach(z => z.Books, c.Books),
            Builders<Author>.Update.Inc(z => z.Version, 0.01),
            Builders<Author>.Update.Set(z => z.LifeExpectancy,
                (c.LastName == "King") ? "Will live forever" : c.LifeExpectancy)
            )));
