    public class MyList : IEnumerable<string>
    {
    	private List<string> internalList;
    
    	// ...
    
    	IEnumerator<string> IEnumerable<string>.GetEnumerator()
    	{
    		return this.internalList.GetEnumerator();
    	}
    
    	IEnumerator IEnumerable.GetEnumerator()
    	{
    		return this.internalList.GetEnumerator();
    	}
    }
