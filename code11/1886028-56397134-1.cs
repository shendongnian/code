    public class PagedResult<T> : IPagedResult
    {
    	public List<T> List { get; private set; }
    	public IEnumerable Data => List;
    
    	public PagingInfo Paging { get; private set; }
    
    	public PagedResult(IEnumerable<T> items, int pageNo, int pageSize, long totalRecordCount)
    	{
    		List = new List<T>(items);
    		Paging = new PagingInfo
    		{
    			PageNo = pageNo,
    			PageSize = pageSize,
    			TotalRecordCount = totalRecordCount,
    			PageCount = totalRecordCount > 0
    				? (int)Math.Ceiling(totalRecordCount / (double)pageSize)
    				: 0
    		};
    	}
    }
