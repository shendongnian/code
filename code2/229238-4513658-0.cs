    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ContainsExample
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var foos = new List<Foo>
    			{
    				new Foo { ID = 1, FooName = "Light Side" },
    				new Foo { ID = 2, FooName = "Dark Side" }
    			};
    
    			var bars = new List<Bar>
    			{
    				new Bar { ID = 1, BarName = "Luke", FooID = 1 },
    				new Bar { ID = 2, BarName = "Han", FooID = 1 },
    				new Bar { ID = 3, BarName = "Obi-Wan", FooID = 1 },
    				new Bar { ID = 4, BarName = "Vader", FooID = 2 },
    				new Bar { ID = 5, BarName = "Palpatine", FooID = 2 },
    				new Bar { ID = 6, BarName = "Fett", FooID = 2 },
    				new Bar { ID = 7, BarName = "JarJar", FooID = 3 }
    			};
    
    			var criteria = from f in foos
    						   select f.ID;
    						   
    			var query = from b in bars
    						where criteria.Contains(b.FooID)
    						select b;
    
    			foreach (Bar b in query)
    			{
    				Console.WriteLine(b.BarName);
    			}
    
    			Console.WriteLine();
    			Console.WriteLine("There should be no JarJar...");
    
    			Console.ReadLine();
    		}
    	}
    
    	public class Foo
    	{
    		public int ID { get; set; }
    		public string FooName { get; set; }
    	}
    
    	public class Bar
    	{
    		public int ID { get; set; }
    		public string BarName { get; set; }
    		public int FooID { get; set; }
    	}	
    }
