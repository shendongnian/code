	String input = "AttDts-14.0.0.1-1-of-3.EXE";
	String pattern = @"([^\-]+)(?=[\-.])";
	Regex regularExpression = new Regex(pattern);
	MatchCollection matchCollection = regularExpression.Matches(input);
	if (matchCollection.Count > 0)
	{
		int groupPosition = 0;
		foreach (var group in matchCollection)
		{
			switch (groupPosition)
			{
				// {productName}
				case 0:
					Console.WriteLine("Product Name: {0}", group);
					break;
				// {version}
				case 1:
					Console.WriteLine("Version: {0}", group);
					break;
				// {X}
				case 2:
					Console.WriteLine("X: {0}", group);
					break;
				// of
				case 3:
					break;
				// {Y}
				case 4:
					Console.WriteLine("Y: {0}", group);
					break;
			}
			++groupPosition;
		}
	}
