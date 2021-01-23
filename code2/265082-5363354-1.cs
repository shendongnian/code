            int min = (int)chart1.ChartAreas[0].AxisX.Minimum;
            int max = (int)chart1.ChartAreas[0].AxisX.Maximum;
            if (max > chart1.Series[0].Points.Count)
                max = chart1.Series[0].Points.Count;
            // this will take only visible points
            var points = chart1.Series[0].Points.Skip(min).Take(max - min);
            var minValue = points.Min(x => x.YValues[0]);
            var maxValue = points.Max(x => x.YValues[0]);
