	public interface ISomeType {
		object Value{get; set;}
	}
	
	public class SomeType1
	{
	  public int Value { get; set; }
	}
	
	public class SomeType2
	{
	  public string Value { get; set; }
	}
		
	public class SomeTypeWrapperFactory
	{
	
	    public static ISomeType CreateSomeTypeWrapper(object aSomeType)
	    {
	    	return aSomeType.CreateDuck<ISomeType>();
	    }        
	}
	
	class Program
	{
	    public static void Main(string[] args)
	    {
	        var someTypes = new object[] {
	            new SomeType1() {Value=1},
	            new SomeType2() {Value="test"}
	        };
	    	
	
	    	foreach(var o in someTypes)
	    	{
	    		Console.WriteLine(SomeTypeWrapperFactory.CreateSomeTypeWrapper(o).Value);
	    	}
	    	Console.ReadLine();
	    }
	}
