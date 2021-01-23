    //linqpad
    void Main()
    {
    	IDictionary<string,object> items = new Dictionary<string,object>();
    	items.Add("test","123");
    	
    	dynamic props = DynamicProperties.LoadFromDictionary(items);
    	
    	string item = props.test;
    	
    	item.Dump();
    }
    
    
    public class DynamicProperties : DynamicObject
    {
    	private DynamicProperties(){}
    	
    	private Dictionary<string, object> dictionary = new Dictionary<string, object>();
    	
    	public static DynamicProperties LoadFromDictionary(IDictionary<string,object> Dictionary)
    	{
    		dynamic dprop = new DynamicProperties();
    		foreach(var item in Dictionary)
    		{
    			dprop.dictionary.Add(item.Key.ToLower(),item.Value);
    		}
    		return dprop;
    	}
    	public override bool TryGetMember(GetMemberBinder binder, out object result)
    	{
    		string name = binder.Name.ToLower();
    		Console.WriteLine("Trying to get " + name);
    		return this.dictionary.TryGetValue(name,out result);
    	}
    	public override bool TrySetMember(SetMemberBinder binder, object value)
    	{
    		Console.WriteLine("TrySetMember: " + value.ToString());
    		this.dictionary[binder.Name.ToLower()] = value;
    		return true;
    	}
    }
