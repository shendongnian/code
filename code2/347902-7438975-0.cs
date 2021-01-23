	static class Foo<T>
	{
		static int count = 0;
		public static int Increment()
		{
			return ++count;
		}
	}
	
	public class Program
	{
		public static void Main()
		{
			Console.WriteLine(Foo<int>.Increment());
			Console.WriteLine(Foo<int>.Increment());
			Console.WriteLine(Foo<double>.Increment());
		}
	}
