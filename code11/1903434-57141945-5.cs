	for (int i = 0; i < NumberList.Count; i++)
	{
		tempList.Clear();
		for (int j = i+1; j < NumberList.Count; j++)
		{
			if (NumberList[i] == NumberList[j])
			{
				tempList.Add(NumberList[i]);				
			}
			else
			{
				// Note that a new series of numbers has began and jump to this position
				i = j;
				break; // end this counting procedure
			}
		}
		
		// at this point evalueate the counter
		if (tempList.Count >= 10)
		{
			finalList.AddRange(tempList.Take(10));
		}		
	}
