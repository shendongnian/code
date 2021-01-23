    public bool Equals(TwoDPoint p)
    {
    	// If parameter is null, return false.
    	if (Object.ReferenceEquals(p, null))
    	{
    		return false;
    	}
    
    	// Optimization for a common success case.
    	if (Object.ReferenceEquals(this, p))
    	{
    		return true;
    	}
    
    	// If run-time types are not exactly the same, return false.
    	if (this.GetType() != p.GetType())
    		return false;
    
    	// Return true if the fields match.
    	// Note that the base class is not invoked because it is
    	// System.Object, which defines Equals as reference equality.
    	return (X == p.X) && (Y == p.Y);
    }
