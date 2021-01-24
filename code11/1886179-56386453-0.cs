    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Hello World");
    		var jsonString = "'none'";
            var deserializedObject = JsonConvert.DeserializeObject<TestEnum>(jsonString);
    		Console.WriteLine(deserializedObject);
    	}
    }
