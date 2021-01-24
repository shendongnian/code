    using System;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var records = new []
    		{
    			new Record { id = 3, name = "jim", score = 2 },
    			new Record { id = 4, name = "jim", score = 1 },
    			new Record { id = 5, name = "jim", score = 3 },
    			new Record { id = 6, name = "Ace", score = 2 },
    			new Record { id = 7, name = "jim", score = 1 }
    		};
    		
    		var result = records.GroupBy(p => p.name)
    							.Select(g => new { Name = g.Key, Score = g.Max(p => p.score) })
                                .ToList();
    		foreach(var item in result)
    			Console.WriteLine("Name: " + item.Name + " Score: " + item.Score);
    	}
    	
    	public class Record
    	{
    		public int id {get; set;}
    		public string name  {get; set;}
    		public int score {get; set;}
    		
    	}
    }
