    public string getEndDate (DateTime startDate,decimal monthCount)
    {
        int y = startDate.Year;
        int m = startDate.Month;
        for (decimal  i = monthCount; i > 1; i--)
        {
            m++;
            if (m == 12)
            { y++;
                m = 1;
            }
        }
        return string.Format("{0}-{1}-{2}", y.ToString(), m.ToString(), startDate.Day.ToString());
    }
