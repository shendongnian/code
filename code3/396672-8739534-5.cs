    public class MyClass
    {
    	private IDictionary<String, String> _store;
    
    	public MyClass()
    	{
    		_store = new Dictionary<String, String>();
    	}
    
        public string MyProp1 { 
        	get { return GetOrDefault("MyProp1"); }
        	set { _store["MyProp1"] = value; }
        }
        public string MyProp2 { 
        	get { return GetOrDefault("MyProp2"); }
        	set { _store["MyProp2"] = value; }
        }
    
        public Boolean HasData()
        {
        	return _store.Any(x => !String.IsNullOrWhiteSpace(x.Value));
        }
    
        public Boolean IsEmpty()
        {
    		return _store.All(x => String.IsNullOrWhiteSpace(x.Value));
        }   
 
        private String GetOrDefault(String propertyName)
        {
    		if (_store.ContainsKey(propertyName))
    		{
    			return _store[propertyName];
    		}
    		return String.Empty;
        }
    }
