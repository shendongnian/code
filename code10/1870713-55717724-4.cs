    private static List<List<object>> SelectDynamicData<T>(IEnumerable<T> data, List<string> properties)
    {
        // get the properties only once per call
        // this isn't fast
        var wantedProperties = typeof(T)
            .GetProperties()
            .Where(x => properties.Contains(x.Name))
            .ToArray();
        var result = new Dictionary<string, List<object>>();
        foreach (var item in data)
        {
            foreach (var wantedProperty in wantedProperties)
            {
                if (!result.ContainsKey(wantedProperty.Name))
                {
                    result.Add(wantedProperty.Name, new List<object>());
                }
                result[wantedProperty.Name].Add(wantedProperty.GetValue(item));
            }
        }
        return result.Select(x => x.Value).ToList();
    }
