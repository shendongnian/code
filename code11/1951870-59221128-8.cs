    private int FindIndexOfFirstNonNumeric(string toScan, int startIndex = 0)
    {
        for (var index = startIndex; index < toScan.Length; ++index)
        {
            if (!char.IsNumber(toScan[index]))
            {
                return index;
            }
        }
        return toScan.Length;
    }
