    class whatever
    {
    	public whatever(object variable)
    	{
    		getVariableValue = variable.ToString;
    	}
    
    	Func<string> getVariableValue;
    
    	public override string ToString()
    	{
    		return getVariableValue();
    	}
    }
    	
    void Main()
    {
    	var type = new { F1 = "test", F2 = "value" };
    	
    	whatever w = new whatever( type );
    	
    	Console.WriteLine( w ); // This will invoke ToString
    }
