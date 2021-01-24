    void setUpGantt(Chart chart)
    {
        chart.Series.Clear();
        Series s = chart.Series.Add("gantt");
        s.ChartType = SeriesChartType.RangeBar;
        s.YValueType = ChartValueType.DateTime;
        s.AxisLabel = "";
        s.IsVisibleInLegend = false;
        Axis ax = chart.ChartAreas[0].AxisX;
        Axis ay = chart.ChartAreas[0].AxisY;
        ax.MajorGrid.Enabled = false;
        ax.MajorTickMark.Enabled = false;
        ax.LabelStyle.Format = " ";
        ax.Enabled = AxisEnabled.False;
        ay.LabelStyle.Format = "HH:mm";
        ay.MajorGrid.Enabled = false;
        ay.MajorTickMark.Enabled = false;
        ay.LineColor = chart.BackColor;
        limitGantt(chart, "8:00", "17:00");
    }
    void limitGantt(Chart chart, string start, string end)
    {
        Axis ax = chart.ChartAreas[0].AxisX;
        ax.Minimum = 0.5;  // we have only one slot
        ax.Maximum = 1.5;  // the bar is centered on its value (1)
        Axis ay = chart.ChartAreas[0].AxisY;
        ay.Minimum = fromTimeString(start).ToOADate();  // we exclude all times..
        ay.Maximum = fromTimeString(end).ToOADate();    // ..outside a given range
    }
