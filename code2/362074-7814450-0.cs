    private static readonly Dictionary<string, double> BathRoomMap =
        new Dictionary<string, double>
    {
        { "1", 1 },
        { "One", 1 },
        { "OneAndHalf", 1.5 },
        { "1.5", 1.5 },
        { "1 1/2", 1.5 }
        // etc
    };
    private static string MapBathRooms(string value)
    {
        double result;
        if (!BathRoomMap.TryGetValue(value, out result))
        {
            return value; // Lookup failed
        }
        return result.ToString();
    }
