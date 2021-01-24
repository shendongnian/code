    using System;
    using System.Reflection;
    public class Program
    {
    	public interface IProcessor
    	{
    		string Process(string text);
    	}
    
    	public class Processors
    	{
    		public class GBR : IProcessor
    		{
    			public string Process(string text)
    			{
    				return $"{text} (processed with GBR rules)";
    			}
    		}
    
    		public class FRA : IProcessor
    		{
    			public string Process(string text)
    			{
    				return $"{text} (processed with FRA rules)";
    			}
    		}
    
    		public static string Process(string country, string text)
    		{
    			var typeName = $"{typeof(Processors).FullName}+{country}";
    			var processor =    (IProcessor)Assembly.GetAssembly(typeof(Processors)).CreateInstance(typeName);
    			return processor?.Process(text);
    		}
    	}
    
    	public static void Main()
    	{
    		Console.WriteLine(Processors.Process("GBR", "This is some text."));
    		Console.WriteLine(Processors.Process("FRA", "This is some more text."));
    	}
    }
