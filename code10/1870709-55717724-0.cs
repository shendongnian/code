    private static List<Dictionary<string, dynamic>> SelectDynamicData<T>(IEnumerable<T> data, List<string> properties)
    {
        // get the properties only once per call
        // this isn't fast
        var wantedProperties = typeof(T)
            .GetProperties()
            .Where(x => properties.Contains(x.Name))
            .ToArray();
        return data
            .Select(x =>
            {
                var wantedData = new Dictionary<string, dynamic>();
                foreach (var wantedProperty in wantedProperties)
                {
                    wantedData[wantedProperty.Name] = wantedProperty.GetValue(x);
                }
                return wantedData;
            })
            .ToList();
    }
