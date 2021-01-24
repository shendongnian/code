    var authors = bookEntities.GroupBy(c => c.ParentId, c => c,
        (key, books) => new Author() { Id = key, Books = books.ToList() });
    await authors.ToAsyncEnumerable().ForEachAsync(async c => await collection.UpdateOneAsync(
        p => p.Id == c.Id,
        Builders<Author>.Update.AddToSetEach(z => z.Books, c.Books)
        ));
