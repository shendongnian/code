    using System;
    using Newtonsoft.Json.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Test(JToken.Parse("{}")); // empty object
    		Test(JToken.Parse("[]")); // empty array
    		Test(JToken.Parse("\"\"")); // empty string
    		Test(JToken.Parse("null")); // null value
    	}
    	
    	private static void Test(JToken token)
    	{
    		Console.WriteLine("Type: " + token.Type.ToString());
    		Console.WriteLine("Token: " + token.ToString());
    		Console.WriteLine("IsEmpty1: " + token.IsNullOrEmpty().ToString());
    		Console.WriteLine("IsEmpty2: " + token.IsNullOrEmpty2().ToString());
    		Console.WriteLine();
    	}
    }
    
    public static class JsonHelper
    {
    	public static bool IsNullOrEmpty(this JToken token)
        {
            return (token == null) ||
                   (token.Type == JTokenType.Array && !token.HasValues) ||
                   (token.Type == JTokenType.Object && !token.HasValues) ||
                   (token.Type == JTokenType.String && token.ToString() == String.Empty) ||
                   (token.Type == JTokenType.Null);
        }
    
    	public static bool IsNullOrEmpty2(this JToken token)
    	{
    		return token == null || string.IsNullOrWhiteSpace(token.ToString());
    	}
    }
