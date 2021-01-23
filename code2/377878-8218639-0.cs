    protected void Page_Load(object sender, EventArgs e)
    {
        RadCalendar1.RangeMinDate = DateTime.Now.AddDays(-14);
        RadCalendar1.RangeMaxDate = DateTime.Now.AddDays(14);
        RadCalendar1.FirstDayOfWeek = (FirstDayOfWeek)DateTime.Now.AddDays(-14).DayOfWeek; 
    }
