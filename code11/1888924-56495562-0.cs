    using System;
    using System.Globalization;
    
    public class Program
    {
    	public static void Main()
    	{
    		var input = "3616,946489653802082229919075063226";
    		var result = decimal.Parse(input, new NumberFormatInfo() { NumberDecimalSeparator = ","});
    		Console.WriteLine(result);
    	}
    }
