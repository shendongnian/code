    List<double?> nullables = new List<double?> {1, null, 2, null, 3};
    // This will contain {1, 2, 3}
    List<double> values = nullables
        .Where(item => item.HasValue)
        .Select(item => item.Value)
        .ToList();
    // This will contain {1, 0, 2, 0, 3}
    List<double> valuesAndDefaults = nullables
        .Select(item => item.GetValueOrDefault())
        .ToList();
