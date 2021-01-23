    using System;
    using System.Text.RegularExpressions;
    
    public class Test
    {
    	public static void Main()
    	{
    		var block = "[0-9a-fA-F]{1,8}";
    		var pattern = $@"(?<from>{block})\s*:\s*(?<to>{block})";
    		Console.WriteLine(Regex.IsMatch("12345678  :87654321", pattern));
    	}
    }
