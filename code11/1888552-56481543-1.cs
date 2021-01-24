    int postBoxCount = 5;
	int signCount = 0;
	int postCount = 0;
	
    for (int i = 0; i < postBoxCount; i++)
	{
		// don't show the total at the very beginning (when i == 0)
		if (i != 0 && i % 4 == 0)
		{
			signCount++;
			Console.WriteLine("SIGN BOX# " + signCount + " SIGN WEIGHT: " + postCount * 4);
			postCount = 0;
		}
		postCount++;
		Console.WriteLine("POST BOX# " + postCount);
	}
    // show the final total
	signCount++;
	Console.WriteLine("SIGN BOX# " + signCount + " SIGN WEIGHT: " + postCount * 4);
