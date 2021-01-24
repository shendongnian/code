    List<int[]> genData = new List<int[]>
    	{
    		new int[] { 1, 2, 3, 4 },
    		new int[] { 1, 2, 3, 4 },
    		new int[] { 1, 2, 3, 4 },
    		new int[] { 1, 2, 3, 4 }
    	};
    
    List<int[]> orgData = new List<int[]>
    	{
    		new int[] { 1, 2, 3, 4 },
    		new int[] { 1, 2, 3, 4 },
    		new int[] { 2, 4, 6, 8 },
    		new int[] { 1, 2, 3, 4 }
    	};
    
    
    var sumsGenData = genData.Select(a => a.Sum()).ToList();
    var sumsOrgData = orgData.Select(a => a.Sum()).ToList();
    
    for (int i = 0; i < sumsGenData.Count; i++)
    {
    	if (sumsGenData[i] != sumsOrgData[i])
    	{
    		orgData[i] = new int[] { 0, 0, 0, 0 };
    	}
    }
