     var result = await collBooks.Aggregate()
                    .Lookup<Books, Authors, LookedUpBooks>(collAuthors, 
                        x => x.AuthorId, 
                        y => y.Id,
                        y => y.LastName
                ).ToListAsync();
    public class LookedUpBooks
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
         public string Id { get; set; }
    
         public string Title { get; set; }
    // Add more properties as you need
    
         public IEnumerable<Authors> InnerAuthors { get; set; }
    }
