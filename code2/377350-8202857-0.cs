    public static string PrepareNumberForInserting(string pNumber)
    {
        int idx = pNumber.IndexOf('7');
        return "3897" + pNumber.SubString(idx >= 0 ? idx + 1 : 0);
    }
