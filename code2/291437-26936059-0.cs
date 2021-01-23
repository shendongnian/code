    public void Foo(object bar)
    {
    	if(bar == null)
    	{
    		throw new ArgumentException(nameof(bar)); // nameof(bar) returns "bar"
    	}
    
    	//....
    }
