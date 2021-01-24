    public class Program
    {
    	public static void Main()
    	{
    		var json = "{\"fuel_distance\": 461.6, \"fuel_distance_um\": \"MI\", \"id\": \"62157\", \"stops\": [{ \"id\": \"zz1dnvtir8j050oW100204\", \"latitude\": 34.0214 }]}";
    		var deserializedObject = JsonConvert.DeserializeObject<MyModel>(json);
    		Console.WriteLine("Id: " + deserializedObject.id);
    		
            var stopIds = deserializedObject.stops.Select(p => p.id);
		    foreach(var id in stopIds)
			  Console.WriteLine("Id child: "+ id);
    	    }
    }
    
    public class MyModel 
    {
    	public decimal fuel_distance {get; set;}
    	public string fuel_distance_um {get; set;}
    	public string id {get; set;}
    	public MyChildModel[] stops {get; set;}
    }
    
    public class MyChildModel 
    {
    	public string id {get; set;}
    	public decimal latitude {get; set;}
    }
