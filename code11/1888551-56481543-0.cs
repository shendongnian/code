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
    // If postCount == 1 then we've just shown a total.  If not, show the final total
	if (postCount == 1)
	{
		signCount++;
		Console.WriteLine("SIGN BOX# " + signCount + " SIGN WEIGHT: " + postCount * 4);
	}
