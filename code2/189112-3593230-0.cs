    private static Dictionary<BookCode, Action<Book>> ctorsByCode = new Dictionary<BookCode, Action<Book>>();
    ...
    ctorsByCode[BookCode.Harry] = () => new Book(BookResource.Harry);
    
    public static Book Create(BookCode code) {
        return ctorsByCode[code]();
    }
