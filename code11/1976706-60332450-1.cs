    public static string PassConv2(string Password, int iL = 3)
    {
        int iTotal = 0;
        var bytes = Encoding.ASCII.GetBytes(Password);
        for (var iLoop = 0; iLoop < bytes.Length; iLoop++)
        {
            // bytes[iLoop] = iValue
            iTotal += bytes[iLoop] * (iL + iLoop);
        }
        return iTotal.ToString();
    }
