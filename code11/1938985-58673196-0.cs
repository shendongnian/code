    private readonly ISearchService service;
    
    //...assuming service injected
    
    public Task Write(ISearchIndexClient indexClient, Search search) {
        return service.UploadContents(indexClient, search.SearchContents);
    }
