    IEnumerable<string> Pairs(IEnumerable<string> strings)
    {
        if (strings.Take(1).Count() == 0)
        {
            return new string[]{};
        }
        return new [] {String.Join("", strings.Take(2))}.Concat(Pairs(strings.Skip(2)));
    }
