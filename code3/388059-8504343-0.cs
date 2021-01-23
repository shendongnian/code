    public static int Your_Name_Here(this string s, string other) 
    {
        for (int counter = 0; counter < s.Length; counter++)
        {
            if (s[counter] != other[counter])
            {
                return counter;
            }
        }
        return -1;
    }
