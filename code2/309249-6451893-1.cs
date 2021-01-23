    String d = "26/06/10";
    DateTime dt = DateTime.ParseExact(d, "dd/MM/yy", CultureInfo.InvariantCulture);
    TimeSpan deltaTimeSpan = dt - DateTime.Now;      // get the time difference between now and the time given
    TimeSpan twelveMonths = new TimeSpan(365,0,0,0); // get a time span of 12 months
    // round the amount of days down and always supply a positive number of days
    int deltaTime = Convert.ToInt32(Math.Abs(Math.Floor(deltaTimeSpan.TotalDays)));
    if (twelveMonths.TotalDays > deltaTime)
    {
        Console.WriteLine(string.Format("It is less than 12 months ({0} days).", deltaTime));
    }
    else if (twelveMonths.TotalDays < deltaTime)
    {
        Console.WriteLine(string.Format("It is more than 12 months ({0} days).", deltaTime));
    }
    else
    {
        Console.WriteLine(string.Format("The difference in time is exactly 12 months. ({0} days).", deltaTime);
    }
