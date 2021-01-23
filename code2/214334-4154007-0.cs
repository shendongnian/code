	static IEnumerable<StateItem> BetterFoo(IEnumerable<StateItem> items, int frameSize, int stepOff)
	{
		// Handle empty sequence
		if (!items.Any())
			yield break;
		
		DateTime currentMoment = items.First().Moment;
		
		foreach (StateItem item in items)
		{
			// stepOff is how many moments to skip
			if (stepOff == 0)
			{				
				// Return the specified number of distinct moments
				if (currentMoment != item.Moment)
				{
					frameSize--;
					currentMoment = item.Moment;
				}
				if (frameSize == 0)
					// Break when we've returned the specified number of frames
					break;
				else
					// Yield the current item
					yield return item;
			}
			else
			{
				// Skip the specified number of distinct moments
				if (currentMoment != item.Moment)
				{
					stepOff--;
					currentMoment = item.Moment;
				}
				if (stepOff == 0)
					yield return item;
			}
		}
	}
