    public static bool CheckContiguousDates(DateTime[] dates)
    {
        //assuming not null and count > 0
        var startDate = dates[0];
        for (int i = 0; i < dates.Length; i++)
        {
            if ((dates[i] - startDate).Days != i)
                return false;
        }
        return true;
    }
