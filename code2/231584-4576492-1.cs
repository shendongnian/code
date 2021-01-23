    public IEnumerable<string> SimpleWrap(string line, int length)
    {
        var s = line;
        while (s.Length > length)
        {
            var result = s.Substring(0, length);
            s = s.Substring(length);
            yield return result;
        }
        yield return s;
    }
