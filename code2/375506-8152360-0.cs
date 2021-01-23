    public class GroupDict
    {
    	const string Separator = ";";
    
    	Dictionary<string, int> _internalDict = new Dictionary<string, int>();
    
    	public void Add(string key1, string key2, int value)
    	{
    		_internalDict.Add(key1 + Separator + key2, value);
    	}
    
    	public int this[string key1, string key2]
    	{
    		get { return _internalDict[key1 + Separator + key2]; }
    		set { _internalDict[key1 + Separator + key2] = value; }
    	}
    
    	public int Count
    	{
    		get { return _internalDict.Count; }
    	}
    }
