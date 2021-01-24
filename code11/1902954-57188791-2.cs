    var rnd = new InclusiveRandom();
    var frequency = Enumerable.Range(sbyte.MinValue, sbyte.MaxValue - sbyte.MinValue + 1).ToDictionary(i => (sbyte)i, i => 0ul);
    var count = 100000000;
    for (var i = 0; i < count; i++)
        frequency[rnd.Next(sbyte.MinValue, sbyte.MaxValue)]++;
    foreach (var i in frequency)
        chart1.Series[0].Points.AddXY(i.Key, (double)i.Value / count);
    chart1.ChartAreas[0].AxisY.StripLines
        .Add(new StripLine { Interval = 0, IntervalOffset = 1d / 256, StripWidth = 0.0003, BackColor = Color.Red });
