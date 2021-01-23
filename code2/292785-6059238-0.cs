    private int FindTrailingNumber(string str)
    {
        string numString = "";
        int numTest;
        for (int i = str.Length - 1; i > 0; i--)
        {
            char c = str[i];
            if (int.TryParse(c.ToString(), out numTest))
            {
                numString = c + numString;
            }
        }
        return int.Parse(numString);
    }
