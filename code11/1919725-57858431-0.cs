    public class Program
    {
    	public static void Main()
    	{
    		var str1 = "foo";
    		var str2 = (str1 = "bar");
    		Console.WriteLine(str2);
    	}
    }
