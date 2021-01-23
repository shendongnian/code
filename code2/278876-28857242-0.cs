    public enum RangeBoundaryType
    {
    	[Description("Exclusive")]
    	Exclusive,
    
    	[Description("Inclusive on both boundaries")]
    	Inclusive,
    
    	[Description("Inclusive on only the lower boundary")]
    	InclusiveLowerBoundaryOnly,
    
    	[Description("Inclusive on only the upper boundary")]
    	InclusiveUpperBoundaryOnly
    }
    
    public static bool Between(this IComparable value, IComparable comparator0, IComparable comparator1, RangeBoundaryType rangeBoundary)
    {
    	switch (rangeBoundary)
    	{
    		case RangeBoundaryType.Exclusive:
    			return (value.CompareTo(comparator0) > 0 && value.CompareTo(comparator1) < 0);
    
    		case RangeBoundaryType.Inclusive:
    			return (value.CompareTo(comparator0) >= 0 && value.CompareTo(comparator1) <= 0);
    
    		case RangeBoundaryType.InclusiveLowerBoundaryOnly:
    			return (value.CompareTo(comparator0) >= 0 && value.CompareTo(comparator1) < 0);
    
    		case RangeBoundaryType.InclusiveUpperBoundaryOnly:
    			return (value.CompareTo(comparator0) > 0 && value.CompareTo(comparator1) <= 0);
    
    		default:
    			return false;
    	}
    }
