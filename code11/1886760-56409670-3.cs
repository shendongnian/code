    static bool IsPalindrome(string s)
    {
        s = s.Replace(" ", "");
        s = s.Replace(",", "");
        s = s.Replace(":", "");
        char[] array = s.ToCharArray();
        Array.Reverse(array);
        string backwards = new string(array);
    
        return s == backwards;
    }
