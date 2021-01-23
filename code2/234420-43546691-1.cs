    void Main()
    {
        DateTime compareTo = DateTime.Parse("8/13/2010 8:33:21 AM");
        DateTime now = DateTime.Parse("2/9/2012 10:10:11 AM");
        var dateSpan = new DateTimeSpan(compareTo, now);
        Console.WriteLine("Years: " + dateSpan.Years);
        Console.WriteLine("Months: " + dateSpan.Months);
        Console.WriteLine("Days: " + dateSpan.Days);
        Console.WriteLine("Hours: " + dateSpan.Hours);
        Console.WriteLine("Minutes: " + dateSpan.Minutes);
        Console.WriteLine("Seconds: " + dateSpan.Seconds);
        Console.WriteLine("Milliseconds: " + dateSpan.Milliseconds);
    }
