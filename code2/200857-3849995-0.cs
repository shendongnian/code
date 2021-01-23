    public List<DateTime> getAllDates(int year, int month)
    {
        var ret = new List<DateTime>();
        for (int i=1; i<=DateTime.DaysInMonth(year,month); i++) {
            ret.Add(new DateTime(year, month, i));
        }
        return ret;
    }
