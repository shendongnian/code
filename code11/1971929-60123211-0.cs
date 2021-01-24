    public class Program
    {
    	public static void Main()
    	{
    		var json = "{ name:phong }";
    		var deserializedObject = JsonConvert.DeserializeObject<MyModel>(json);
    		Console.WriteLine(deserializedObject.name);
    	}
    }
    
    public class MyModel 
    {
    	public string name {get; set;}
    }
