    public static string PassConv3(string Password, int iL = 3)
    {
        int iTotal = 0;
        for (var iLoop = 0; iLoop < Password.Length; iLoop++)
        {
            iTotal += Password[iLoop] * (iL + iLoop);
        }
        return iTotal.ToString();
    }
