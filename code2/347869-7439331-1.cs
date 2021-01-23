    public static IList<Range> GetListIntersections(IList<Range> rangeList1, IList<Range> rangeList2)
    {
        var intersection = new List<Range>();
        
        //add intersection of each range
        foreach (var x in rangeList1)
        {
            foreach (var y in rangeList2)
            {
                var intersect = GetIntersection(x, y);
                if (intersect != null)
                {
                    intersection.Add(intersect);
                }
            }
        }
        
        //remove ranges that are subsets of other ranges
        intersection.RemoveAll(x => intersection.Any(y => y != x && y.Start >= x.Start && y.End <= x.End));
        
        return intersection;
    }
    
    public static Range GetIntersection(Range range1, Range range2)
    {
        int greatestStart = range1.Start > range2.Start ? range1.Start : range2.Start;
        int smallestEnd = range1.End < range2.End ? range1.End : range2.End;
        
        //no intersection
        if (greatestStart > smallestEnd)
        {
            return null;
        }
        
        return new Range { Start = greatestStart, End = smallestEnd };
    }
