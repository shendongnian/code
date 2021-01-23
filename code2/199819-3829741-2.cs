		static void Main(string[] args)
		{
			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine(NativeMethods.IsControlKeyDown());
				System.Threading.Thread.Sleep(100);
			}
		}
