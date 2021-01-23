    internal class Foo
	{
		public string Bar { get; set; }
	}
	class Program
	{
		static void Main(string[] args)
		{
			Foo f = new Foo()
			        	{
			        		Bar = "Baaz"
			        	};
			Console.WriteLine("Now the old way sugar");
			Foo f2 = new Foo();
			f2.Bar = "Baaz";
		}
	}
