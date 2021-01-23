    void Main()
    {
    	Console.WriteLine(5.Convert()); // Prints "5"
    	Console.WriteLine("Empty String" + 0.Convert());
    }
    
    // Define other methods and classes here
    public static class ExtMethods{
    	public static string Convert(this int value)
    	{
    		return value == 0 ? string.Empty : value.ToString();
    	}
    }
