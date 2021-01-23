    private int MonthValue = 0;
    private bool bChanged = false;
    private void Form1_Load(object sender, EventArgs e)
    {
        MonthValue = monthCalendar1.TodayDate.Month;
    }
    private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
    {
        
        if (MonthValue != monthCalendar1.SelectionStart.Month)
        {
            //changed
            bChanged = true;
            MonthValue = monthCalendar1.SelectionStart.Month;
        }
        else
        {
            //not changed
            bChanged = false;
        }
    }
