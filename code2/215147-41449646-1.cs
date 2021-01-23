    void Main()
    {
    	var myObject1 = new Foo();
    	var myObject2 = new Hoo();
    
    	//elided...
    
    	{
    		var _ = myObject1;
    		_.MyPropertyA = 2;
    		_.MyPropertyB = "3";
    	}
    
    	{
    		var _ = myObject2;
    		_.MyPropertyX = 5;
    		_.MyPropertyY = "asd";
    	}
    }
