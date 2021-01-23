    private bool matchPattern(string string1, string string2)
    {
        bool result = (string1.Length == string2.Length);
        char[] chars1 = string1.ToCharArray();
        char[] chars2 = string2.ToCharArray();
        for (int i = 0; i < string1.Length; i++)
        {
            if (Char.IsLetter(chars1[i]) != Char.IsLetter(chars2[i]))
            {
                result = false;
            }
            if (Char.IsLetter(chars1[i]) && (chars1[i] != chars2[i]))
            {   
                //Characters must be identical
                result = false;
            }
            if (Char.IsDigit(chars1[i]) != Char.IsDigit(chars2[i]))
                result = false;
        }
        return result;
    }
