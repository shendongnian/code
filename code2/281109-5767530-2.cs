	static void Main(string[] args)
	{
		long counter = 0;
		var sw = Stopwatch.StartNew();
		var sb = new StringBuilder();
		var text = File.ReadAllText(Path.Combine(Environment.ExpandEnvironmentVariables(@"%UserProfile%\Desktop"), "spacestation.txt"));
		for (int i = 0; i < text.Length; i++)
		{
			int start = i;
			while (i < text.Length && (char.IsDigit(text[i]) || text[i] == '-' || text[i] == '.'))
			{ i++; }
			if (i > start)
			{
				sb.Append(text, start, i - start);
				float value = Parse(sb);
				sb.Remove(0, sb.Length);
				counter++;
			}
		}
	}
