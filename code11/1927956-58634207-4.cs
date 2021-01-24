    var bookGroups = bookEntities.GroupBy(c => c.ParentId, c => c,
        (key, books) => new { key, books });
    await bookGroups.ToAsyncEnumerable().ForEachAsync(async c => await collection.UpdateOneAsync(
        Builders<Author>.Filter.Eq(p => p.Id, c.key),
        Builders<Author>.Update.AddToSetEach(z => z.Books, c.books.ToList())
        ));
