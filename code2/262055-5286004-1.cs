    linq("and a rhino 11", new char[] { 'a', 'b', 'c' }); // result: { 'a' }
    public char[] linq(string text, char[] limitChars)
    {
        char[] result = text
            .Where( c => limitChars.Contains(c))
            .GroupBy(x => x)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToArray();
        return result;
    }  
