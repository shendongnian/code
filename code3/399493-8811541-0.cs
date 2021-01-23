    public static IEnumerable<int> ParseInts(IEnumerable<char> idList)
    {
        bool valid = false;
        int working = 0;
        foreach (char c in idList)
        {
            if (c >= '0' && c <= '9')
            {
                valid = true;
                working = (working*10) + (c - '0');
            }
            else if (c == ',')
            {
                if(valid)
                    yield return working;
                valid = false;
                working = 0;
            }
            else if(!Char.IsWhiteSpace(c))
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        if (valid)
            yield return working;
    }
