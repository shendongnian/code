    public class C : I
    {
    	private List<int> list;
    	
    	// Implement the interface explicitly.
    	IEnumerable<int> I.f
    	{
    		get { return list; }
    		set { list = new List<int>(value); }
    	}
    	
    	// This hides the IEnumerable member when using C directly.
        public List<int> f
    	{
    		get { return list; }
    		set { list = value; }
    	}
    }
