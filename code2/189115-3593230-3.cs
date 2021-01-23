    private static Dictionary<BookCode, BookResource> codeResources = new Dictionary<BookCode, BookResource>();
    ...
    ctorsByCode[BookCode.Harry] = BookResource.Harry;
    
    public static Book Create(BookCode code) {
        return new Book(codeResources[code]);
    }
