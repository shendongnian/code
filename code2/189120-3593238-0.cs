    delegate Book Create();
    private static Dictionary<BookCode, Create> ctorsByCode 
        = new Dictionary<BookCode, Create>();
    ctorsByCode[BookCode.Harry] = () => new Book(BookResource.Harry);
    ctorsByCode[BookCode.Julian] = () => new Book(BookResource.Julian); 
    public static Book Create(BookCode code) {
        return ctorsByCode[code]();
    }
