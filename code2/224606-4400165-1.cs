    private bool matchPattern (string string1, string string2)
    {
        bool result = (string1.Length == string2.Length);
        char[] chars1 = string1.ToCharArray();
        char[] chars2 = string2.ToCharArray();
        for (int i = 0; i < string1.Length; i++ )
        {
            if (isAlpha(chars1[i]) != isAlpha(chars2[i]))
                result = false;
            if (isNumeric(chars1[i]) != isNumeric(chars2[i]))
                result = false;
        }
        return result;
    }
