    public bool IsInTheRange(int parameter)
    {
        string range = "0A-0F";
        string rangeArray = range.Split('-')
                                 .Select(x => int.Parse(x, NumberStyles.HexNumber))
                                 .ToArray();
        return (parameter >= rangeArray[0]) && (parameter <= rangeArray[1]);
    }
