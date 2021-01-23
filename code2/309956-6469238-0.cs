    using (var writer = new StreamWriter("text.txt"))
    {
        foreach (StatisticsData item in StatisticsCollection)
        {
            writer.WriteLine(item.ToString());
        }
    }
