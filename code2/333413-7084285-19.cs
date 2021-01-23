    static IList<PropertyInfo> GetWritableProperties(Type type)
    {
        lock (SyncObj)
        {
            List<PropertyInfo> props;
            if (!PropLookup.TryGetValue(type, out props))
            {
                props = type.GetProperties()
                    .Select(p => new { p, Atts = p.GetCustomAttributes(typeof(WriteableAttribute), inherit: true) })
                    .Where(p => p.Atts.Length != 0)
                    .OrderBy(p => ((WriteableAttribute)p.Atts[0]).Order)
                    .Select(p => p.p)
                    .ToList();
                PropLookup.Add(type, props);
            }
            return props;
        }
    }
