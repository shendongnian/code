    double dblCalcTotal = Sum(txtJan.Text, txtFeb.Text, txtMar.Text .....);
    private static double Sum(params string[] list)
    {
        double result = 0;
        foreach (string s in list)
        {
            result += Utils.GetDecimal(s, 0);
        }
        return result;
    }
