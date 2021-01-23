    List<long> hundredThousandItemsInOrignalList;
    List<long> fiftyThousandItemsToRemove;
    // populate lists...
    Dictionary<long, long> originalItems = hundredThousandItemsInOrignalList.ToDictionary(i => i);
    foreach (long i in fiftyThousandItemsToRemove)
    {
        originalItems.Remove(i);
    }
    List<long> newList = originalItems.Select(i => i.Key).ToList();
