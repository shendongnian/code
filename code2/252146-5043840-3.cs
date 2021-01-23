    IEnumerable<Tuple<double, double>> Average(List<List<Tuple<double, double>>> data)
    {
    	if (data == null || data.Count <= 2 || data.Any(list => list == null || list.Any(p => p == null))) throw new ArgumentException();
    	Func<double, double> square = d => d * d;
    	Func<Tuple<double, double>, Tuple<double, double>, double> euclidianDistance = (a, b) => Math.Sqrt(square(a.Item1 - b.Item1) + square(a.Item2 - b.Item2));
    
    	var firstList = data[0];
    	for (int i = 0; i < firstList.Count; i++)
    	{
    		int[] previousIndices = new int[data.Count];//the indices of points which are closest to the previous point firstList[i - 1]. 
    		//(or zero if i == 0). This is kept track of per list, except the first list.
    		var closests = new Tuple<double, double>[data.Count];//an array of points used for caching, of which the average will be yielded.
    		closests[0] = firstList[i];
    		for (int listIndex = 0; listIndex < data.Count; listIndex++)
    		{
    			var list = data[listIndex];
    			double distance = euclidianDistance(firstList[i], list[previousIndices[listIndex]]);
    			for (int j = previousIndices[listIndex] + 1; j < list.Count; j++)
    			{
    				var distance2 = euclidianDistance(firstList[i], list[j]);
    				if (distance2 < distance)//if it's closer than the previously checked point, keep searching. Otherwise stop the search and return an interpolated point.
    				{
    					distance = distance2;
    					previousIndices[listIndex] = j;
    				}
    				else
    				{
    					closests[listIndex] = list[previousIndices[listIndex]];
    					break;
    				}
    			}
    		}
    		yield return new Tuple<double, double>(closests.Select(p => p.Item1).Average(), closests.Select(p => p.Item2).Average());
    	}
    }
