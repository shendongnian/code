		static int Double(int number)
		{
			return number * 2;
		}
		static void Main(string[] args)
		{
		
			int i = 2;
			Func<int> f = () => Double(i);
			i = 3;
			Console.WriteLine(f()); // prints 6 and not 4
			
		}
