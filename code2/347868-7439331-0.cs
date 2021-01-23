    public IList<int> GetRangeIntersection(Range range1, Range range2)
    {
        int greaterOfMinimums = range1.Min > range2.Min ? range1.Min : range2.Min;
        int lesserOfMaximums = range1.Max < range2.Max ? range1.Max : range2.Max;
        if (lesserOfMaximums < greaterOfMinimums)
        {
            //no intersection, return empty list
            return new int[]{};
        }
        
        return Enumerable.Range(greaterOfMinimums , lesserOfMaximums - greaterOfMinimums + 1).ToList();
    }
