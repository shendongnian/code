    DateTime testDate = new DateTime(2011, 12, 15, 00, 00, 00, DateTimeKind.Local);
    DateTime endDate = testDate.AddDays(1);
    while (testDate.Date != endDate.Date)
    {
        Console.WriteLine(testDate.ToString());
        testDate = testDate.AddHours(1);
    }
