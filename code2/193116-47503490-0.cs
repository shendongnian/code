		private static int b = Foo();
		private static int a = 4;
		private static int Foo()
		{
			Console.WriteLine(a);
			a = 3;
			Console.WriteLine(a);
			return 2;
		}
		public static void Main()
		{
			Console.WriteLine(a);
		}
