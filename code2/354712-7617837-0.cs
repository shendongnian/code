    using System;
	using System.Collections.Generic;
	using System.Linq;
	public class Program
	{
		//MAIN 
		private static void Main(string[] args)
		{
			IEnumerable<Func<int, int, int>> operationsList = 
				new Func<int,int, int>[] { Add, Sub };
			//CALL EVENTs AND WRITE 
			Console.WriteLine(operationsList.Sum(operation => operation(20, 15)));
			//PAUSE 
			Console.ReadLine();
		}
		//ADDITION 
		private static int Add(int x, int y)
		{
			return x + y;
		}
		//SUBTRACTION 
		private static int Sub(int x, int y)
		{
			return x - y;
		}
	}
