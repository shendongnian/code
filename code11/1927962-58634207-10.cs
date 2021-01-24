    // Given a known book id, how do I update only that book? (non-async, also works with UpdateOne)
    var bookId = new Guid("447eb762-95e9-4c31-95e1-b20053fbe215");
    collection.FindOneAndUpdate(
        Builders<Author>.Filter.ElemMatch(c => c.Books, p => p.Id == bookId),
        Builders<Author>.Update.Set(z => z.Books[-1].Title, "amazing new title")
        );
    
    // Given a known book id, how do I update only that book? (async)
    var bookId = new Guid("447eb762-95e9-4c31-95e1-b20053fbe215");
    await collection.UpdateOneAsync(
        Builders<Author>.Filter.ElemMatch(c => c.Books, p => p.Id == bookId),
        Builders<Author>.Update.Set(z => z.Books[-1].Title, "here we go again")
        );
    // Given several known book ids, how do we update each of the books?
    var bookIds = new List<Guid>()
    {
        new Guid("c7ba6add-09c4-45f8-8dd0-eaca221e5d93"),
        new Guid("bc4c35c3-3857-4250-9449-155fcf5109ec"),
        new Guid("447eb762-95e9-4c31-95e1-b20053fbe215")
    };       
    await bookIds.ToAsyncEnumerable().ForEachAsync(async c => await collection.UpdateOneAsync(
        p => p.Books.Any(z => z.Id == c),
        Builders<Author>.Update.Set(z => z.Books[-1].Title, "new title yup yup")
        ));
