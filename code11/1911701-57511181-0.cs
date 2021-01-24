    public class SomeClass
    {
     	public string Key {get; set;}
    }
    
    public interface ISomeInterface
    {
    	string Value { get; set; }
    	SomeClass SomeClass { get; set;}
    }
    
    public class SomeInterfaceImplementation : ISomeInterface
    {
    	public SomeInterfaceImplementation()
    	{
    		SomeClass = new SomeClass()
    		{
    			Key = "ABC"
    		};
    	}
    	public string Value { get; set; }
    	public SomeClass SomeClass { get; set; }
    }
    
    public class Program
    {
    	
    	public static void Main()
    	{
    		var example = new SomeInterfaceImplementation()
    		{
    			Value = "A value",
    		} as ISomeInterface;
    		Console.WriteLine($"{example.SomeClass.Key} has value '{example.Value}'");
    	}
    }
