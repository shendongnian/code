    public DateTime ConvertDate(int julianDate)
    {
        DateTime dt = new DateTime("2000-01-01");
        return dt.AddDays(julianDate - 1);
    }
