    static public string PersianDateString(DateTime d)
    {
        var pc = new PersianCalendar();
        return string.Format("{0:0000}/{1:00}/{2:00}",
            pc.GetYear(d), pc.GetMonth(d), pc.GetDayOfMonth(d));
    }
