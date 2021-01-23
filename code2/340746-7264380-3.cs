    // assuming your objects are of type ClassX and your properties are decimals
    static Dictionary<string, Func<ClassX, decimal>> PropertyLookup = 
        new Dictionary<string, Func<ClassX, decimal>>();
    foreach (var day in bydates)
    {
        var bymile_bydate = bymile.Where(x => x.Date == day).ToList();
    
        foreach (var r in results)
        {
            var name = r.name;
            if (!PropertyLookup.ContainsKey(name))
                PropertyLookup[name] = (Func<ClassX, decimal>)Delegate.CreateDelegate(
                    typeof(Func<ClassX, decimal>),
                    typeof(ClassX).GetProperty(name).GetGetMethod());
            r.data.Add(bymile_bydate.Sum(PropertyLookup[name]).Value);
        }
    }
