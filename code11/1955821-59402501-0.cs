    using System;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		
    		var validTypes = new [] {1, 2};
    		var invalidTypes = new [] {1, 2, 3};
    		
    		Console.WriteLine(validTypes.Any(p => !Enum.IsDefined(typeof(GroupTypes), p)));
    		Console.WriteLine(invalidTypes.Any(p => !Enum.IsDefined(typeof(GroupTypes), p)));
    
    		
    	}
    	
    	public enum GroupTypes
    	{
    			Downtime = 1,
    			Uptime = 2
    	}
    }
