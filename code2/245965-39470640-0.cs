    var bulk = new BulkOperations();
    var books = GetBooks();
    
    bulk.Setup<Book>()
    .ForCollection(books)
    .WithTable("Books")
    .AddAllColumns()
    .BulkInsertOrUpdate()
    .MatchTargetOn(x => x.ISBN)
    
    bulk.CommitTransaction("DefaultConnection");
