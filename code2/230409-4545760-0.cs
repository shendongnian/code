    private int NumberFromElementName(string name)
    {
        // Or search for the last '_' using name.LastIndexOf()
        var numString = name.Substring("Control_".Length);
        return Int32.Parse(numString);
    }
