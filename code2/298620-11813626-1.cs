    bool testCaseThree(string str)
    {
        if (string.IsNullOrEmpty(str))
            return false;
        for (int i = 0; i < str.Length; i++)
        {
            if (char.IsLower(str[i]))
                return true;
        }
        return false;
    }
