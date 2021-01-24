    public class Program
    {
    	public static void Main()
    	{
    		var isBetween = "abc".IsBetween(1, 'a', 'c');
    		Console.WriteLine(isBetween); //True
    	}
    }
    
    public static class Extensions
    {
    	public static bool IsBetween(this String str, int index, char start, char end)
    	{
    		var left = str[index - 1];
    		var right = str[index + 1];
    		return left == start && right == end;
    	}
    }
