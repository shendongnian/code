    public interface IMyInterface
    {
    	string GroupName { get;  }
    	int RowSpan { get; }
    }
    
    private IEnumerable<IMyInterface> GetRowGroups()
    {
    	var list =
    		from item in table
    		select new
    		{
    			GroupName = groupedTable.Key.column1,
    			RowSpan = groupedTable.Count()
    		}
    		.ActLike<IMyInterface>();
    	
    	return list;
    }
