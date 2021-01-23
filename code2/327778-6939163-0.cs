    protected void Page_Load(object sender, EventArgs e)
    {
        // Declare and get DateTime values
        DateTime StartDate = System.DateTime.Now;
        DateTime EndDate = System.DateTime.UtcNow;
     
        // Find time difference between two dates
        TimeSpan TimeDifference = StartDate - EndDate;
     
        // Write difference in hours and minutes
        Response.Write("Time difference between server time and Coordinated Universal Time (UTC) is " +
            TimeDifference.Hours.ToString() + " hours ");
        if (TimeDifference.Minutes != 0)
            Response.Write(" and " + TimeDifference.Minutes.ToString() + " minutes.");
     
    }
