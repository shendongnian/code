    DateTime startDate = DateTime.Today.Add(new TimeSpan(4, 0, 0));
    DateTime endDate = DateTime.Today.Add(new TimeSpan(16, 0, 0));
    double[] percentages = new[] { 0, 0.5, 1 };
    foreach (double percentage in percentages)
    {
        var result = GetTime(percentage, startDate, startDate);
        Console.WriteLine(result.ToString());
    }
