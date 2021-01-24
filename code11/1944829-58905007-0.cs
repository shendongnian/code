    var input = "1 A & B 2 C & D"; // your input
	
	var words = input.Split();
	
	var builder = new StringBuilder();
	
	foreach (var word in words)
	{
		if (int.TryParse(word, out var value))
		{
			if (builder.Length > 0)
			{
				Console.WriteLine(builder.ToString()); // or add it to some collection
				builder.Clear();
			}
			Console.WriteLine(word); // or add it to some collection
		}
		else 
		{
			if (builder.Length > 0)
			{			
				builder.Append(' ');
			}
			builder.Append(word);
		}
	}
	
	if (builder.Length > 0) // leftovers
	{
		Console.WriteLine(builder.ToString()); // or add it to some collection
	}
