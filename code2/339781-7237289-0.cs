    DateTime today = new DateTime(2011, 8, 29);
    DateTime nextWeek = new DateTime(2011, 9, 4);
    
    TimeSpan difference = nextWeek - today;
    
    List<DateTime> days = new List<DateTime>();
    
    for (int i = 0; i <= difference.Days; i++)
    {
       days.Add(today.AddDays(i));
    }
    
    foreach (var dateTime in days)
    {
       Console.WriteLine(dateTime);
    }
    Console.ReadLine();
