    foreach(var item in strings.Zip(types,(x,y)=> new {Value = x, Type = y }))
    	{
    		try
    		{
    			Console.WriteLine($"{Convert.ChangeType(item.Value,item.Type)} can be converted to {item.Type}");
    		}
    		catch(Exception e)
    		{
    			Console.WriteLine(e.Message);
                // Do the required processing
    		}
    		
    	}
