    private Chart buildChart()
    {
        // Build Chart
        var chart = new Chart();
 
        // Create chart here
        chart.Titles.Add(CreateTitle());
        chart.Legends.Add(CreateLegend());
        chart.ChartAreas.Add(CreateChartArea());
        chart.Series.Add(CreateSeries());
 
        return chart;
    }
 
    private string getChartImage(Chart chart)
    {
        using (var stream = new MemoryStream();
        {
           string img = "<img src='data:image/png;base64,{0}' alt='' usemap='#ImageMap'>";
           chart.SaveImage(stream, ChartImageFormat.Png);
           string encoded = Convert.ToBase64String(stream.ToArray());
           return String.Format(img, encoded);
        }
    }
