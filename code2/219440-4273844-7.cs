    public IEnumerable<IPublication> GetBooks()         
    {         
        List<Book> books = new List<Book>();         
        return books.Cast<IPublication>();         
    }
