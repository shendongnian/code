    object s1 = "TestString";
       var k = s1.GetType().ToString();
      	switch(k)
    	{
    	case  "System.String":
    	 
    		{
    		Console.WriteLine("string");
    			 break;
    		}
         //Add Other case also
    	default:
    		{
    			Console.WriteLine("Not Sting");
    			break;
    		}
    	}
