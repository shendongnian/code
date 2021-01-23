    Dictionary<Index, Pairing> openPairings;
    List<Index> possibilities;
    
    foreach(pairing)
    {
    	if(openPairings.ContainsKey(pairing.Index))
    	{
    		// This is the closing of the pair
    		// When there are no other open strands at the time of closing,
    		// AND the pairing was in the possibilities list, it could be the largest
    		if(possibilities.Contains(pairing.Index))
    		{
    			// The opening entry: openPairings[pairing.Index]
    			// The closing pairing: pairing
    			// Do your size check here to find the largest
    		}
    		openPairings.Remove(pairing.Index);
    	}
    	else
    	{
    		// This is the opening of the pair
    		// There must be no other open pairings or there will be an overlap OR
    		// the outer pairing is larger anyway, as it completely engulfs this pairing
    		if(openPairings.IsEmpty)
    			possibilities.Add(pairing.Index);
    		openPairings.Add(pairing.Index, pairing);
    	}
    }
