    bool testCaseTwo(string str)
    {
        if (string.IsNullOrEmpty(str))
            return false;
        return Regex.IsMatch(str, "[a-z]");
    }
