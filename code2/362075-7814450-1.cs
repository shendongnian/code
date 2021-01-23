    private static readonly Dictionary<string, string> BathRoomMap =
        new Dictionary<string, string>
    {
        // Note: I've removed situations where we'd return the
        // same value anyway... no need to map "1" to "1" etc
        { "One", "1" },
        { "OneAndHalf", "1.5" },
        { "1 1/2", 1.5 }
        // etc
    };
    private static string MapBathRooms(string value)
    {
        string result;
        if (!BathRoomMap.TryGetValue(value, out result))
        {
            return value; // Lookup failed
        }
        return result;
    }
