	using System;
	using System.Collections.Generic;
	
	public class Fruit
	{
		public string Name {get; set;}
		public double Price {get; set;}
	}
	
	public class Program
	{
		public static void Main()
		{
			List<Fruit> _myFruit = new List<Fruit>();
		
			_myFruit.Add(new Fruit{Name="apple", Price=15   });
 			_myFruit.Add(new Fruit{Name="pear", Price=12.5  });
 			_myFruit.Add(new Fruit{Name="",  Price=10       });
 			_myFruit.Add(new Fruit{Name="",  Price=0.45     });
			// etc...
		}
	}
	
