    private static readonly IEnumerable<char> CharacterSet = Enumerable.Range(0, char.MaxValue + 1).Select(Convert.ToChar).Where(c => !char.IsControl(c));
    public static string ExpandCharacterSet(string set)
    {
        var sb = new StringBuilder();
        int start = 0;
        bool invertSet = false;
        if (set.Length == 0) 
            return "";
        if (set[0] == '[' && set[set.Length - 1] == ']')
            set = set.Substring(1, set.Length - 2);
        if (set[0] == '^')
        {
            invertSet = true;
            set = set.Substring(1);
        }
        while (start < set.Length - 1)
        {
            int dash = set.IndexOf('-', start + 1);
            if (dash <= 0 || dash >= set.Length - 1)
                break;
            sb.Append(set.Substring(start, dash - start - 1));
            char a = set[dash - 1];
            char z = set[dash + 1];
            for (var i = a; i <= z; ++i)
                sb.Append(i);
            start = dash + 2;
        }
        sb.Append(set.Substring(start));
        if (!invertSet) return sb.ToString();
        var A = new HashSet<char>(CharacterSet);
        var B = new HashSet<char>(sb.ToString());
        A.ExceptWith(B);
        return new string(A.ToArray());
    }
