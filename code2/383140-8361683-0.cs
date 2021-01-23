    static void Main(string[] args)
		{
			var x = typeof(IDictionary<string, string>);
			var y = typeof(IDictionary<,>);
			Console.WriteLine(x.GetGenericTypeDefinition() == y);
		}
