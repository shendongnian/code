    class Program
	{
		const string SomeString = "Some String"; // gets interned
		static void Main(string[] args)
		{
			var s1 = SomeString; // use interned string
			var s2 = SomeString; // use interned string
			var s = "String";
			var s3 = "Some " + s; // no interning 
			Console.WriteLine(s1 == s2); // uses interning comparison
			Console.WriteLine(s1 == s3); // do NOT use interning comparison
		}
    }
