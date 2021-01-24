    chart1.Titles.Add("Line Chart");
    chart1.ChartAreas[0].Axes[0].MajorGrid.Enabled = false;
    chart1.ChartAreas[0].Axes[1].MajorGrid.Enabled = false;
    List<string> brand = new List<string>() { "a", "b", "c", "d", "e", "f", "g" };
    List<int> price = new List<int>() { 1, 3, 2, 4, 1, 5, 7 };
    chart1.Series.Clear();
    chart1.Series.Add("Price");
    chart1.Series["Price"].Points.DataBindXY(brand, price);
    chart1.Series[0].ChartType = SeriesChartType.Line;
    Dictionary<string, int> peak = new Dictionary<string, int>();
    // Exclude the first and last point
    for (int i = 1; i < price.Count - 1; i++)
    {
        if (price[i] > price[i + 1] && price[i] > price[i + 1])
        {
            // save x,y value and index
            peak.Add(brand[i] + price[i], i);
        }
    }
