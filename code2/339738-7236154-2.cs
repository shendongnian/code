    using System;
    using System.Linq;
    using System.Reflection;
    // try this for fun:
    using IMyInterface=System.Collections.IEnumerable;
           
    namespace TestThat
    {
    	class MainClass
    	{
    		
    		public static void Main (string[] args)
    		{
    			var x = AppDomain.CurrentDomain.GetAssemblies()
    				.SelectMany(a => a.GetTypes())
    				.Where(t => typeof(IMyInterface).IsAssignableFrom(t))
    				.Where(t => !(t.IsAbstract || t.IsInterface))
    			    .Except(new [] { typeof(IMyInterface) });
    			
    			Console.WriteLine(string.Join("\n", x.Select(y=>y.Name).ToArray()));
    			
    		}
    	}
    }
