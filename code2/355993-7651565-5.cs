	static void Main(string[] args)
	{
		String input = "AttDts-14.0.0.1-1-of-3.EXE";
		String[] splits = input.Split(new char[] { '-' });
		int splitCounter = 0;
		foreach (var split in splits)
		{
			switch (splitCounter)
			{
				case 0:
					var productName = split;
					Console.WriteLine("Product Name: {0}", productName);
					break;
				case 1:
					var version = split;
					Console.WriteLine("Version: {0}", version);
					break;
				case 2:
					var x = split;
					Console.WriteLine("X: {0}", x);
					break;
				case 3:
					break;
				case 4:
					var y = split.Split(new char[] { '.' })[0];
					Console.WriteLine("Y: {0}", y);
					break;
			}
			++splitCounter;
		}
	}
