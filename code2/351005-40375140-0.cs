    public class Test
    {
    	public static void Main()
    	{
    		var httpValueCollection = HttpUtility.ParseQueryString(string.Empty);
            httpValueCollection["param1"] = "value1";
            httpValueCollection["param2"] = "value2";
    		Console.WriteLine(httpValueCollection.ToString());
    		
    		var nameValueCollection = new NameValueCollection();
            nameValueCollection["param1"] = "value1";
            nameValueCollection["param2"] = "value2";
    		Console.WriteLine(nameValueCollection.ToString());	
    	}
    }
