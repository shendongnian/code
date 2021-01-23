    public static bool HasSpecialCharacter(this string s)
    {
        foreach (var c in s)
        {
            if(!char.IsLetterOrDigit(c))
            {
                return true;
            }
        }
        return false;
     }
