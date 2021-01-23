    List<DateTime> contiguousDates = new List<DateTime>
    {
        new DateTime(2011, 05, 05),
        new DateTime(2011, 05, 06),
        new DateTime(2011, 05, 07),
    };
    List<DateTime> randomDates = new List<DateTime>
    {
        new DateTime(2011, 05, 05),
        new DateTime(2011, 05, 07),
        new DateTime(2011, 05, 08),
    };
    Console.WriteLine(contiguousDates.IsContiguous());
    Console.WriteLine(randomDates.IsContiguous());
