    public static bool IsInTheRange(int parameter) 
    {
        string range = "0A-0F";
        var tokens = range
            .Split('-')
            .Select(x => int.Parse(x, NumberStyles.HexNumber))
            .ToArray();
        return tokens[0] <= parameter && parameter <= tokens[1];
    }
