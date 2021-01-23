    private void chart1_AxisViewChanged(object sender, ViewEventArgs e)
        {
            if(e.Axis.AxisName == AxisName.X)
            {
                int start = (int)e.Axis.ScaleView.ViewMinimum;
                int end = (int)e.Axis.ScaleView.ViewMaximum;
                List<double> allNumbers = new List<double>();
                foreach(Series item in chart1.Series)
                    allNumbers.AddRange(item.Points.Where((x, i) => i >= start && i <= end).Select(x => x.YValues[0]).ToList());
                double ymin = allNumbers.Min();
                double ymax = allNumbers.Max();
                chart1.ChartAreas[0].AxisY.ScaleView.Position = ymin;
                chart1.ChartAreas[0].AxisY.ScaleView.Size = ymax - ymin;
            }
        }
