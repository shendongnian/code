    public void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
        DateTime startTime = Convert.ToDateTime(dateTimePicker1.Value);
        DateTime endTime = DateTime.Today;
        TimeSpan span = endTime.Subtract(startTime);
        var totalDays = span.TotalDays;
        var totalYears = Math.Truncate(totalDays / 365);
        var totalMonths = Math.Truncate((totalDays % 365) / 30);
        var remainingDays = Math.Truncate((totalDays % 365) % 30);
        frm.UpdateLabel(string.Format("{0} year(s), {1} month(s) and {2} day(s)", totalYears, totalMonths, remainingDays));
    
    }
    
