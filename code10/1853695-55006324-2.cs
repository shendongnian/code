    static int[] GenerateIncreasingDecreasing(int level)
    {
        var tempRange = Enumerable.Range(0, level).ToArray();
        var indexMap = (tempRange.Length < 2) ?
                        tempRange :
                        tempRange.Concat(Enumerable.Range(1, level-2).Reverse());
        return indexMap.ToArray();
    }
    
