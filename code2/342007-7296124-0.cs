    private static void AddOddNumberToRange(NumberRanges oNumberRanges, int p)
    { 
        oNumberRanges.NumberGroups[1].Number.Add(p);
    }
    private static void AddEvenNumberToRange(NumberRanges oNumberRanges, int p)
    {
        oNumberRanges.NumberGroups[0].Number.Add(p);
    }
