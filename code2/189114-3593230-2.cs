    private static Dictionary<BookCode, Func<Book>> ctorsByCode = new Dictionary<BookCode, Func<Book>>();
    ...
    ctorsByCode[BookCode.Harry] = () => new Book(BookResource.Harry);
    
    public static Book Create(BookCode code) {
        return ctorsByCode[code]();
    }
