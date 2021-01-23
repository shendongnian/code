    public static string IntToCurrencyString(int number, string separator)
    {
        string moneyReversed = "";
        string strNumber = number.ToString();
        int processedCount = 0;
        for (int i = (strNumber.Length - 1); i >= 0; i--)
        {
            moneyReversed += strNumber[i];
            processedCount += 1;
            if ((processedCount % 3) == 0 && processedCount < strNumber.Length)
            {
                moneyReversed += separator;
            }
        }
        string money = "";
        for (int i = (moneyReversed.Length - 1); i >= 0; i--)
        {
            money += moneyReversed[i];
        }
        return money;
    }
