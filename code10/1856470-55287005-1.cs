    public IQueryable<Book> Get(ODataQueryOptions<Book> options)
    {
    	var displayData = _dataService.RetrieveData().AsQueryable();
    	
    	_oDataSortingService.ReplaceSingleSortAsStringArguments(options);
    	
    	var results = options.ApplyTo(displayData);
    
    	return results as IQueryable<Book>;
    }
