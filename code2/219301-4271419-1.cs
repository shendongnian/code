    public static IEnumerable<T> WalkRanges<T>(IEnumerable<T> source, List<Pair<int, int>> ranges)
    {
    	Debug.Assert(ranges == null || ranges.Count > 0);
    
    	int currentItem = 0;
    	Pair<int, int> currentRange = new Pair<int, int>();
    	int currentRangeIndex = -1;
    	bool betweenRanges = false;
    	if (ranges != null)
    	{
    		currentRange = ranges[0];
    		currentRangeIndex = 0;
    		betweenRanges = currentRange.First > 0;
    	}
    
    	using (IEnumerator<T> enumerator = source.GetEnumerator())
    	{
    		while (enumerator.MoveNext())
    		{
    
    			if (ranges != null)
    			{
    				if (betweenRanges)
    				{
    					if (currentItem == currentRange.First)
    						betweenRanges = false;
    					else
    					{
    						currentItem++;
    						continue;
    					}
    				}
    			}
    
    			yield return enumerator.Current;
    
    			if (ranges != null)
    			{
    				if (currentItem == currentRange.Second)
    				{
    					if (currentRangeIndex == ranges.Count - 1)
    						break; // We just visited the last item in the ranges
    
    					currentRangeIndex = currentRangeIndex + 1;
    					currentRange = ranges[currentRangeIndex];
    					betweenRanges = true;
    				}
    			}
    
    			currentItem++;
    		}
    	}
    }
