    void Main()
    {
    	var result = simpleIntParser.TryParse("1");
    	if(result)
    	{
    		Console.WriteLine((int)result);
    	} else {
    		Console.WriteLine("Failed");
    	}
    	
    	result = simpleIntParser.TryParse("a");
    	if(result)
    	{
    		Console.WriteLine((int)result);
    	} else {
    		Console.WriteLine("Failed");
    	}
    	
    	
    }
    
    public class simpleIntParser
    {
    	public bool result {get; private set;}
    	public int value {get; private set;}
    	
    	private simpleIntParser(bool result, int value)
    	{
    		this.result = result;
    		this.value = value;
    	}
    	
    	public static simpleIntParser TryParse(String strValue)
    	{
    		int value;
    		var result = int.TryParse(strValue, out value);
    		return new simpleIntParser(result, value);
    	}
    	
    	public static implicit operator int(simpleIntParser m)
    	{
    		return m.value;
    	}
    	
    	public static implicit operator bool(simpleIntParser m)
    	{
    		return m.result;
    	}
    }
