    public bool GetComparativeFunction(String property, SearchModel options)
    {
        if (options.SelectedSearch == "Contains") return property.Contains(options.SearchTerm);
    
        if (options.SelectedSearch == "Equals") return property.Equals(options.SearchTerm);
    
        return false; //default option
    }
    public Expression<Func<InstrumentLists, bool>> GetLambdaExpressionFromFilter(SearchModel options)
    {
        if (options.SelectedType == "Process_No")
            return p => GetComparativeFunction(p.Process_No, options);
        if (options.SelectedType == "PLC_No")
            return p => GetComparativeFunction(p.PLC_No, options);
        return p => true; //default option
    }
