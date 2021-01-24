    static bool IsPalindrome(string s)
    {
        char[] array = s.ToCharArray();
        Array.Reverse(array);
        string backwards = new string(array);
    
        return s == backwards;
    }
