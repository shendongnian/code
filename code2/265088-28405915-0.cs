        foreach (ChartArea area in chart1.ChartAreas)
        {
          List<double> allNumbers = new List<double>();
          foreach (Series item in chart1.Series)
            if (item.ChartArea == area.Name)
              allNumbers.AddRange(item.Points.Where((x, i) => i >= start && i <= end).Select(x => x.YValues[0]).ToList());
          double ymin = allNumbers.Min();
          double ymax = allNumbers.Max();
          if (ymax > ymin)
          {
            double offset = 0.02 * (ymax - ymin);
            area.AxisY.Maximum = ymax + offset;
            area.AxisY.Minimum = ymin - offset;
          }
        }
