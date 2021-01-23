    class Filter
    {
    	// Can be converted into a property as well.
    	public virtual string GetFilterText { return "filter"; }
    }
    
    class DistrFilter : Filter
    {
    	public override string GetFilterText { return "distr filter"; }
    }
