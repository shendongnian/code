    public class Program
    {
    	public static void Main()
    	{
    		var result = MyStrangeType.Strange1 && MyStrangeType.Strange2;
    		
    		Console.WriteLine(result.GetType().FullName);
    	}
    }
