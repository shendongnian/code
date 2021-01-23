    public static string RemoveSpecialCharacters(string str)
    {
        //change regular expression as per your need
        return Regex.Replace(str, "[^a-zA-Z0-9_.]", "", RegexOptions.Compiled);
    }
