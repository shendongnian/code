    var pairs = _systemData.SelectMany(s =>
        _institutionData.Select(i => new { System = s, Institution = i }));
    
    _values.AddRange(pairs.Select(x =>
    {
        bool match = x.System.LookupValue == x.Insitution.OriginalSystemLookupValue;
    
        return match ? new LookupValue(x.Institution) : new LookupValue(x.System);
    }));
