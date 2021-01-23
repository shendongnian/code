    // assuming your objects are of type ClassX and your properties are decimals
    Dictionary<string, Func<ClassX, decimal>> PropertyLookup = 
        new Dictionary<string, Func<ClassX, decimal>>
        { { "TotalIssues", x => x.TotalIssues },
          { "TotalCritical", x => x.TotalCritical },
        };
    foreach (var day in bydates)
    {
        var bymile_bydate = bymile.Where(x => x.Date == day).ToList();
    
        foreach (var r in results)
        {
            var name = r.name;
            r.data.Add(bymile_bydate.Sum(PropertyLookup[name]).Value);
        }
    }
