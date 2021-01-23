	class Program
	{
		static double epsilon = 0.000001;
		
		static bool DoubleEquals(double value1, double value2)
		{
    		return Math.Abs(value1 - value2) < epsilon;
		}
		static void Print(double percent, TextWriter sw)
		{
			if (DoubleEquals(percent % 1, .0))
			{
				sw.Write(" {0}%", (int)percent);
			}
			else
			{
				sw.Write(" {0:f1}%", percent);
			}
		}
		
		public static void Main(string[] args)
		{
			Print(11.0, Console.Out);
			Print(14.000000000000004, Console.Out);
			Print(12.0, Console.Out);
			Print(6.0, Console.Out);
			Print(4.0, Console.Out);
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
