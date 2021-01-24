    public static void Main(string[] args)
    {
        var charts = new List<Chart>
        {
            new Chart {ChartId = 1, chartStatusId = 1},
            new Chart {ChartId = 2, chartStatusId = 1},
            new Chart {ChartId = 3, chartStatusId = 1},
            new Chart {ChartId = 1, chartStatusId = 2},
            new Chart {ChartId = 2, chartStatusId = 2},
            new Chart {ChartId = 3, chartStatusId = 2},
        };
        Console.WriteLine("ChartId  chartStatusId");
        var filtered = charts
            .GroupBy(c => c.ChartId)
            .Select(c => new Chart {ChartId = c.Key, chartStatusId = c.Max(i => i.chartStatusId)});
        foreach (var chart in filtered)
        {
            Console.WriteLine($"{chart.ChartId,4}{chart.chartStatusId,11}");
        }
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
