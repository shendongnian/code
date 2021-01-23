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
		
			_myFruit.Add(new Fruit{Name="Apple",Price=10.00});
			// etc...
		}
	}
	
