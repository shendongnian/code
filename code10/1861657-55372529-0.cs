    Legend legend = new Legend();
    Chart chartA = new Chart();     // <<---!
    chartA.BackColor = Color.White;
    chartA.Width = 370;
    chartA.Height = 250;
    chartA.Location = new Point(48, 35);
    chartA.Name = textBox1.Text;
    chartA.Legends.Add(legend);     // <<---!
    legend.Title = "Age of The Employees";     // <<---!
    chartA.ChartAreas.Add(new ChartArea("ca"));     // <<---!
    chartA.ChartAreas["ca"].BackColor = Color.LightSeaGreen;
    Series s1 = chartA.Series.Add("s1");     // <<---!
    s1.ChartType = SeriesChartType.Pie;
    s1.Points.AddY(12);
    s1.Points.AddY(32);
    ..
