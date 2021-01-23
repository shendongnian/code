    var bulk = new BulkOperations();
    var books = GetBooks();
    
    using (TransactionScope trans = new TransactionScope())
    {
    	using (SqlConnection conn = new SqlConnection(ConfigurationManager
    	.ConnectionStrings["SqlBulkToolsTest"].ConnectionString))
    	{
            bulk.Setup<Book>()
                .ForCollection(books)
                .WithTable("Books") 
                .AddAllColumns()
                .BulkInsert()
                .Commit(conn);
    	}
    
    	trans.Complete();
    }
