	static void Main(string[] args)
	{
		long counter = 0;
		var sw = Stopwatch.StartNew();
		var sb = new StringBuilder();
		var text = File.ReadAllText("spacestation.obj");
		for (int i = 0; i < text.Length; i++)
		{
			int start = i;
			while (i < text.Length &&
				(char.IsDigit(text[i]) || text[i] == '-' || text[i] == '.'))
			{ i++; }
			if (i > start)
			{
				sb.Append(text, start, i - start); //Copy data to the buffer
				float value = Parse(sb); //Parse the data
				sb.Remove(0, sb.Length); //Clear the buffer
				counter++;
			}
		}
		sw.Stop();
		Console.WriteLine("{0:N0}", sw.Elapsed.TotalSeconds); //Only a few ms
	}
