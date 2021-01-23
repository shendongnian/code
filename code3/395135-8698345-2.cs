    public static int GetQuarter(DateTime date)
    {
        if (date.Month >= 4 && date.Month <= 6)
            return 1;
        else if (date.Month >= 7 && date.Month <= 9)
            return 2;
        else if (date.Month >= 10 && date.Month <= 12)
            return 3;
        else 
            return 4;
    }
