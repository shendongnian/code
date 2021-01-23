    class Priority
    {
    	private int _index;
    	private DateTime _updated;
    
    	public int Index 
    	{ 
    		get { return _index; } 
    		set
    		{
    			_index = value;
    			_updated = DateTime.Now;
    		}		
    	}
    	public DateTime  Updated  { get { return _updated; } }
    }
    
