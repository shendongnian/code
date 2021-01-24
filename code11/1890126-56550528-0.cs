    using System;
    using System.Linq;
    using System.Collections.Generic;
					
    public class Program
    {
	   public class Item1 
	   {
		  public int Codigo1 { get; set; }
		
		  public string Name { get; set; }
		
		  public int Codigo2 { get; set; }		
	  }
	
	  public class Item2
	  {
		public int Cod1 { get; set; }
		
		public int Cod2 { get; set; }
	  }
	
	  public static void Main()
	  {
		var list1 = new List<Item1>() {
			new Item1() { Codigo1 = 1, Name = "cat11", Codigo2 = 1 },
			new Item1() { Codigo1 = 2, Name = "cat12", Codigo2 = 1 },
			new Item1() { Codigo1 = 3, Name = "cat13", Codigo2 = 1 },
			new Item1() { Codigo1 = 4, Name = "cat14", Codigo2 = 1 },
			new Item1() { Codigo1 = 5, Name = "cat15", Codigo2 = 1 },
			new Item1() { Codigo1 = 6, Name = "cat16", Codigo2 = 1 },
			new Item1() { Codigo1 = 1, Name = "cat31", Codigo2 = 3 },
			new Item1() { Codigo1 = 1, Name = "cat41", Codigo2 = 4 }
		};
		
		var list2 = new List<Item2>() {
			new Item2() { Cod1 = 1, Cod2 = 4 },
			new Item2() { Cod1 = 1, Cod2 = 5 },
			new Item2() { Cod1 = 3, Cod2 = 1 }
		};
		
		var result = from l1 in list1
			         join l2 in list2 
					 on new { a = l1.Codigo1, b = l1.Codigo2 } equals  new { a= l2.Cod2, b= l2.Cod1 }
		             select new { Codigo1 = l1.Codigo1, Name = l1.Name, Codigo2 = l1.Codigo2 };
			        
		
		foreach(var r in result)
		{
			Console.WriteLine(r.Codigo1 + " " + r.Name + " " + r.Codigo2);
		}
	  }
    }
