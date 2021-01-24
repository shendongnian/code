    private static List<Book> Foo()
    {
        using (var lib = new Controller())
        {
            lib.Dispose();
            return lib.Library;  // Now 'Library' is null
        } 
    }
