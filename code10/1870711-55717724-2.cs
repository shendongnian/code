    private static List<List<dynamic>> SelectDynamicData<T>(IEnumerable<T> data, List<string> properties)
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
                var wantedData = new List<dynamic>();
                foreach (var wantedProperty in wantedProperties)
                {
                    wantedData.Add(wantedProperty.GetValue(x));
                }
                return wantedData;
            })
            .ToList();
    }
