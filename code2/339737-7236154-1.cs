    using System;
    using System.Linq;
    using System.Reflection;
    using IMyInterface=System.Object;
    
    // interface IMyInterface { }
    
    class Test1 : IMyInterface { }
    class Test2 : IMyInterface { }
    
    
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
