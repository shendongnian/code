    private bool ValidString(string myString)
    {
        char[] validChars = new char[] { 'A', '!' };
        if (!myString.StartsWith("A"))
            return false;
        if (myString.Contains("!!"))
            return false;
        foreach (char c in myString)
        {
            if (!validChars.Contains(c))
                return false;
        }
        return true;
    }
    private List<string> SplitMyString(string myString)
    {
        List<string> resultList = new List<string>();
        if (ValidString(myString))
        {
            string resultString = "";
            foreach (char c in myString)
            {
                if (c == 'A')
                    resultString += c;
                if (c == '!')
                {
                    resultString += c;
                    resultList.Add(string.Copy(resultString));
                    resultString = "";
                }
            }
        }
        return resultList;
    }
