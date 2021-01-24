        using System;
        public class Program{
    
    	public static void Main()
    	{
    		Guid gg = Guid.NewGuid();
    		Console.WriteLine(gg);
    		string ss = Encode(gg);
    		Console.WriteLine(ss);
    		Console.WriteLine(Decode(ss));
    	}
    	public static string Encode(Guid guid)
    	{
    		string encoded = Convert.ToBase64String(guid.ToByteArray());
    		encoded = encoded.Replace("/", "_").Replace("+", "-");
    		return encoded.Substring(0, 22);
    	}
    
    	public static Guid Decode(string value)
    	{
    		value = value.Replace("_", "/").Replace("-", "+");
    		byte[] buffer = Convert.FromBase64String(value + "==");
    		return new Guid(buffer);
    	}
    
    
    
    
    }
