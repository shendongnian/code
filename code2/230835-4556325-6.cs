    public static IEnumerable<string> SaeedsApproach(this string str, int allowedLength)
    {
        var ret1 = str.Split(' ');
        string current = "";
        foreach (var item in ret1)
        {
            if (item.Length + 1 + current.Length <= allowedLength)
            {
                current += ' ' + item;
                if (current.Length >= allowedLength)
                {
                    yield return current;
                    current = "";
                }
            }
            else
            {
                yield return current;
                current = "";
            }
        }
    }
