	using System;
	public static class MyModule
	{
		public static void Main()
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			int i = 0;
			for (i = 0; i <= 1000; i++) {
				Console.Write(Strings.ChrW(i));
				if (i % 50 == 0) { \\ break every 50 chars
					Console.WriteLine();
				}
			}
			Console.ReadKey();
		}
	}
