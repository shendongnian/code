    public static void AddNumberingPrefix(string[] strings)
    {
        for (int i = 0; i < strings.Length; i++)
        {
            strings[i] = $"{i+1}. {strings[i]}";
        }
    }
