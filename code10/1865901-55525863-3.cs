    TimeSpan startTime = new TimeSpan(4, 0, 0);
    TimeSpan endTime = new TimeSpan(16, 0, 0);
    double[] percentages = new[] { 0, 0.5, 1 };
    foreach (double percentage in percentages)
    {
        var result = GetTime(percentage, startTime, endTime);
        Console.WriteLine(result.ToString());
    }
