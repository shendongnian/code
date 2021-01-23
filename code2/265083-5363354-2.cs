            DateTime date = DateTime.Now;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 20;
            Random r = new Random((int)date.Ticks);
            chart1.Series[0].ChartType = SeriesChartType.Candlestick;
            chart1.Series[0].Color = Color.Green;
            chart1.Series[0].XValueType = ChartValueType.Time;
            chart1.Series[0].IsXValueIndexed = true;
            chart1.Series[0].YValuesPerPoint = 4;
            chart1.Series[0].CustomProperties = "MaxPixelPointWidth=10";
            for (int i = 0; i < 100; i++ )
            {
                DataPoint point = new DataPoint(date.AddHours(i).ToOADate(), new double[] { r.Next(10, 20), r.Next(30, 40), r.Next(20, 30), r.Next(20, 30) });
                chart1.Series[0].Points.Add(point);
            }
            int min = (int)chart1.ChartAreas[0].AxisX.Minimum;
            int max = (int)chart1.ChartAreas[0].AxisX.Maximum;
            if (max > chart1.Series[0].Points.Count)
                max = chart1.Series[0].Points.Count;
            var points = chart1.Series[0].Points.Skip(min).Take(max - min);
            var minValue = points.Min(x => x.YValues[0]);
            var maxValue = points.Max(x => x.YValues[1]);
            chart1.ChartAreas[0].AxisY.Minimum = minValue;
            chart1.ChartAreas[0].AxisY.Maximum = maxValue;
