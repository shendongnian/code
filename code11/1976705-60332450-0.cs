    public static string PassConv(string Password)
    {
        int iLoop;
        int iL;
        int iTotal;
        int iValue;
        string sPassConv = "";
        iL = 3;
        iTotal = 0;
        for (iLoop = 1; iLoop <= Password.Length; iLoop++)
        {
            string sNo = Password.Substring(iLoop - 1, 1);
            iValue = Encoding.ASCII.GetBytes(sNo)[0];
            iTotal = iTotal + iValue * (iL + iLoop - 1);
            sPassConv = iTotal.ToString();
        }
        return sPassConv;
    }
