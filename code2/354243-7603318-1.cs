    int[] DaysOfWeek = (int[])Enum.GetValues(typeof(DayOfWeek));
    int NumberOfDaysInWeek = DaysOfWeek.Length;
    int NumberOfMasks = 1 << NumberOfDaysInWeek;
    int[,] OffsetLookup = new int[NumberOfDaysInWeek, NumberOfMasks];
    
    //populate offset lookup
    for(int mask = 1; mask < NumberOfMasks; mask++)
    {
    	for(int d = 0; d < NumberOfDaysInWeek; d++)
    	{
    		OffsetLookup[d, mask] = (from x in DaysOfWeek
    								 where ((1 << x) & mask) != 0
    								 orderby Math.Abs(x - d)
    								 select (x - d) % NumberOfDaysInWeek).First();
    	}
    }
