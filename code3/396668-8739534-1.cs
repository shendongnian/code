    public class MyClass
    {
    	private IDictionary<String, String> _store;
    
    	public MyClass()
    	{
    		_store = new Dictionary<String, String>();
    	}
    
        public string MyProp1 { 
        	get { return _store["MyProp1"]; }
        	set { _store["MyProp1"] = value; }
        }
        public string MyProp2 { 
        	get { return _store["MyProp2"]; }
        	set { _store["MyProp2"] = value; }
        }
    
        public Boolean HasData()
        {
        	return _store.Any(x => !String.IsNullOrWhitespace(x.Value));
        }
    
        public Boolean IsEmpty()
        {
    		return _store.All(x => String.IsNullOrWhitespace(x.Value));
        }
    }
