	static void Main()
	{
		int? x = 5;
		PrintType(x);	
	}
	static void PrintType<T>(T val) {
		Console.WriteLine("Compile-time type: " + typeof(T));
		Console.WriteLine("Run-time type: " + val.GetType());
	}
