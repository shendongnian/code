    public interface IPagedResult
    {
    	IEnumerable Data { get; }
    
    	PagingInfo Paging { get; }
    
    	//any other properties you might need
    }
