    Int32 numberOfDays = 5;
    DateTime dt = DateTime.Now;
    for (int i = 0; i < numberOfDays ; i++)
    {
        Console.WriteLine(dt.AddDays(i).DayOfWeek);
    }
