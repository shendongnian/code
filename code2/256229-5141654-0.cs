    public static string Strip(string source)
    {
        char[] array = new char[source.Length];
        int arrayIndex = 0;
        bool inside = false;
        for (int i = 0; i < source.Length; i++)
        {
            char let = source[i];
            if (let == '<')
            {
                inside = true;
                continue;
            }
            if (let == '>')
            {
                inside = false;
                continue;
            }
            if (!inside)
            {
                array[arrayIndex] = let;
                arrayIndex++;
            }
        }
        string text =  new string(array, 0, arrayIndex);
        return System.Text.RegularExpressions.Regex.Replace(text, @"\s+", " ").Trim();
    }
