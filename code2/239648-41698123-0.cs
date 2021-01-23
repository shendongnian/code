    static Random rand = new Random();
    public static string ShuffleString(string s)
    {
        if (string.IsNullOrEmpty(s))
            return s;
        char[] chars = s.ToCharArray();
        char c;
        int j;
        for(int i = chars.Length - 1; i > 0; i--)
        {
            j = rand.Next(i + 1);  // Next max is exclusive
            if (j == i)
                continue;
            c = chars[j];
            chars[j] = chars[i];
            chars[i] = c;
        }
        return chars.ToString();
    }
