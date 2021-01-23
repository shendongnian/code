    DateTime start = DateTime.Today;
    DateTime end = DateTime.Today.AddDays(7);
    for (DateTime current = start; current <= end; current = current.AddDays(1))
    {
        Console.WriteLine(current);
    }
