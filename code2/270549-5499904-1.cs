    var readableIndex = OpenReadableIndex();
    var searcher = new IndexSearcher(readableIndex.Directory);
    var multiParser = new MultiFieldQueryParser(termsToSearchIn, readableIndex.Analyzer);
    
    var query = multiParser.Parse(terms);
    Hits hits = null;
    Sort sort = new Sort(new SortField[]
    {
    	new SortField("LastEditedYear", true),
    	new SortField("LastEditedMonth", true),
    	new SortField("LastEditedDay", true),
    	new SortField("LastEditedHour", true),
    	new SortField("LastEditedMinute", true)
    }); 
    if(sort != null)
    {
    	try
    	{
    		hits = searcher.Search(query, sort);
    	}
    	catch(SystemException) // Lucene throws a SystemException when trying to sort an empty response.
    	{
    		return new List<string>();
    	}
    }
