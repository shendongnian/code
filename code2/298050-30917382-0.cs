    public static Boolean isAlphaNumeric(string strToCheck)
    {
        Regex rg = new Regex(@"\w+");
        return rg.IsMatch(strToCheck);
    }
