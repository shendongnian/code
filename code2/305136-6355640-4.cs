    using System;
    using System.Reflection;
    
    namespace ConsoleApplication
    {
    	public class Program
    	{
    		public static void Main(string[] args)
    		{
    			// Get the assembly we're going to check for attributes.
    			// You will want to load the assemblies you want to check at runtime.
    			Assembly assembly = typeof(Program).Assembly;
    
    			// Get all assembly plugin attributes that the assembly contains.
    			object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyPluginAttribute), false);
    			if (attributes.Length == 1)
    			{
    				// Cast the attribute and get the assembly plugin type from it.
    				var attribute = attributes[0] as AssemblyPluginAttribute;
    				AssemblyPluginType pluginType = attribute.PluginType;
    			}
    		}
    	}
    }
