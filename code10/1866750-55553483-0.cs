    public static boolean IsAllSpaces(string input)
    {
        if(input == null || input == String.Empty)
        {
            return false;
        }
        foreach(char c in input)
        {
            if(c != " ")
            {
                return false;
            }
        }
        return true;
    }
