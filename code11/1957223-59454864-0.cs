	public static void Main()
	{
		StringBuilder sb = new StringBuilder("Default Text");
		Console.WriteLine($"Before function call: {sb.ToString()}");
		AppendString(sb);  //Function call
		Console.WriteLine($"After function call: {sb.ToString()}");
	}
	
	public static void AppendString(StringBuilder sb)
	{
		sb.Append(" Hello world");
		Console.WriteLine($"Inside function: {sb.ToString()}");
	}
