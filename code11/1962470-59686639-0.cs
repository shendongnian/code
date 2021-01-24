    public static DateTime GetTomorrow(DateTime incomingDate)
    {
        return incomingDate.AddDays(1).Date;
    }
**Update**
Example of how this works,
    DateTime dt = DateTime.Now;
    Console.WriteLine(dt);
    Console.WriteLine(dt.Date);
**Output**
1/10/2020 1:03:27 PM
1/10/2020 12:00:00 AM
