    public class Program
    {
    	public static void Main()
    	{
    		var response = new GenericFoo<DataClass>(new DataClass()
    		{Id = 10}, "Test");
    		//serialises completely fine
    		var json = JsonConvert.SerializeObject(response);
    		
    		var obj = JsonConvert.DeserializeObject<GenericFoo<DataClass>>(json);
    		Console.WriteLine(obj.Data.Id); // Prints 10
    	}
    }
