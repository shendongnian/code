    using System;
    
    static class Utility<T, TReturn>
    	where T : TReturn
    {
    	public static TReturn Change(T arg)
    	{
    		return (TReturn)(arg);
    	}
    }
    
    
    class Program
    {
    	static void Main(string[] args)
    	{
    		string i = "100";
    
    		try
    		{
    			object s = Utility<string, object>.Change(i);
    			Console.WriteLine(s);
    		}
    		catch (Exception ex)
    		{
    			Console.WriteLine(ex);
    		}
    	}
    }
