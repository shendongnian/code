    void Main()
    {
    	Print("Hello world");
    	Print(42);
    }
    
    static void Print(object o)
    {
    	switch (o)
    	{
            // Note that I am reusing the variable name "value" in each case.
    		case string value:
    			Console.WriteLine("STRING: " + value);
    			break;
    
    		case int value:
    			Console.WriteLine("INT: " + value.ToString());
    			break;
    	}
    }
