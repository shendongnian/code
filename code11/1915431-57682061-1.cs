    private static int FirstDiff(string str1, string str2)
    {
        int length = Math.Min(str1.Length, str2.Length);
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        for (int i = 0; i < length; ++i)
        {
            if (textInfo.ToUpper(str1[i]) != textInfo.ToUpper(str2[i]) ||
                textInfo.ToLower(str1[i]) != textInfo.ToLower(str2[i]))
            {
                return i;
            }
        }
        return str1.Length == str2.Length ? -1 : length;
    }
