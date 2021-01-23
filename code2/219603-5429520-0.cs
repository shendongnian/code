    string toDec(string input)
    {
        Dictionary<string, char> resDec =
            (from p in input.ToCharArray() where p > 127 select p).Distinct().ToDictionary(
                p => String.Format(@"&#x{0:D};", (ushort)p));
        foreach (KeyValuePair<string, char> pair in resDec)
            input = input.Replace(pair.Value.ToString(), pair.Key);
        return input;
    }
