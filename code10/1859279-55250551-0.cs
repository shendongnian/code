    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string x = "0TEST";
    		if(x.Substring(0,1).Equals(("0"))){
    			Console.WriteLine("Starts with 0");
    		}else{
    			Console.WriteLine("Doesn't start with 0");
    		}
    	}
    }
