      bool AreStringsEqual(string s1, string s2)
    {
        if ((!String.IsNullOrEmpty(s1) && !String.IsNullOrEmpty(s2)))
        {
            if (s1 == s2)
            {
                return true;
            }
        }
        return false;
    }
