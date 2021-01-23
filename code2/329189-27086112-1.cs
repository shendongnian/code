    double pointWidth = 0.375;
    double pointOffset = pointWidth * 0.5;
    // Add first series - column
    _Chart.Add("Series1");
    _Chart.Series["Series1"].ChartType = SeriesChartType.Column;
    _Chart.Series["Series1"]["PointWidth"] = pointWidth.ToString();
    for (int ii = 0; ii < 10; ii++)
    {
      _Chart.Series["Series1"].Points.AddXY(ii - pointOffset, YourYValueHere);
    }
    // Add second series - stacked column
    _Chart.Add("Series2");
    _Chart.Series["Series2"].ChartType = SeriesChartType.Column;
    _Chart.Series["Series2"]["PointWidth"] = pointWidth.ToString();
    for (int ii = 0; ii < 10; ii++)
    {
      _Chart.Series["Series2"].Points.AddXY(ii + pointOffset, YourYValueHere);
    }
    // Add thrid series - stacked column
    _Chart.Add("Series3");
    _Chart.Series["Series3"].ChartType = SeriesChartType.Column;
    _Chart.Series["Series3"]["PointWidth"] = pointWidth.ToString();
    for (int ii = 0; ii < 10; ii++)
    {
      _Chart.Series["Series3"].Points.AddXY(ii + pointOffset, YourYValueHere);
        _Chart.ChartAreas["Area1"].AxisX.CustomLabels.Add(
         ii - 0.5, ii + 0.5, ii);
    }
    _Chart.ChartAreas["Area1"].AxisX.Minimum = -0.5;
    _Chart.ChartAreas["Area1"].AxisX.Maximum =
                  _Chart.Series["Series3"].Points.Count - 0.5;
    _Chart.ChartAreas["Area1"].AxisX.LabelStyle.IsEndLabelVisible = true;
    _Chart.ChartAreas["Area1"].AxisX.IsMarginVisible = false;
