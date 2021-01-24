    private static readonly Dictionary<int, int> YearIdMap = new Dictionary<int, int>();
    private static string GetNextId()
    {
        // Get the current year
        int year = DateTime.Today.Year;
        // Something to store the next id value in
        int nextId;
        YearIdMap.TryGetValue(year, out nextId); // Get the current value or 0
        // Increment our number
        nextId++;
        // Save the new value along with this year
        YearIdMap[year] = nextId;
        // Return the value to the caller in the format: id/year
        return $"{year}/{nextId}";
    }
