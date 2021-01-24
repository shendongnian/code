    {
            "Items": [
                    {
                            "Name": "tour",
                            "Attributes": [
                                    {
                                            "Name": "groups",
                                            "Value": 1
                                    },
                                    {
                                            "Name": "individual",
                                            "Value": 2
                                    }
                            ]
                    },
                    {
                            "Name": "demo",
                            "Attributes": [
                                    {
                                            "Name": "this is demo",
                                            "Value": 3
                                    },
                                    {
                                            "Name": "design pattern",
                                            "Value": 99
                                    }
                            ]
                    }
            ]
    }
    Types foo = JsonSerializer.Deserialize<Types>(jsonString);
    public class TypeAttribute
    {
    	public string Name { get; set; }
    	public int Value { get; set; }
    }
    public class Type
    {
    	private readonly ICollection<TypeAttribute> _attributes;
    
    	public Type()
    	{
    		_attributes = new Collection<TypeAttribute>();
    	}
    
    	public void AddAttributes(IEnumerable<TypeAttribute> attrs)
    	{
    		foreach(TypeAttribute ta in attrs)
    		{
    			_attributes.Add(ta);
    		}
    	}
    
    	public string Name { get; set; }
    	public IEnumerable<TypeAttribute> Attributes
    	{
    		get { return _attributes; }
    
    		set 
    		{ 
    			foreach(TypeAttribute ta in value)
    			{
    				_attributes.Add(ta);
    			}
    		}
    	}
    }
    public class Types
    {
    	ICollection<Type> _items;
    
    	public Types()
    	{
    		_items = new Collection<Type>();
    	}
    
    	public void AddItems(IEnumerable<Type> tps)
    	{
    		foreach (Type t in tps)
    		{
    			_items.Add(t);
    		}
    	}
    
    	public IEnumerable<Type> Items
    	{
    		get { return _items; }
    
    		set
    		{
    			foreach (Type t in value)
    			{
    				_items.Add(t);
    			}
    		}
    	}
    }
