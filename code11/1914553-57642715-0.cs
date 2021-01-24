    private void rb_range_CheckedChanged(object sender, EventArgs e)
    {
        Chart chart = chart8;
        Series s = chart.Series[0];
        s.ChartType = SeriesChartType.Line;
        s.XValueType = ChartValueType.DateTime;
        s.YValueType = ChartValueType.Double;
        Axis ax = chart.ChartAreas[0].AxisX;
        Axis ay = chart.ChartAreas[0].AxisY;
        //ax.IsMarginVisible = true;
        //ax.IsStartedFromZero = false;
        ax.Interval = 1;
        if (rb_week.Checked)
        {
            setValues('w', 123);
            ax.IntervalType = DateTimeIntervalType.Days;
            ax.LabelStyle.Format = "dddd";
            //ax.IntervalOffset = 1;
            ax.Minimum = points.Min(x => x.XValue); 
            ax.Maximum = points.Max(x => x.XValue); 
        }
        else if (rb_month.Checked)
        {
            setValues('m', 123);
            ax.IntervalType = DateTimeIntervalType.Days;
            ax.LabelStyle.Format = "dd";
            ax.Minimum = points.Min(x => x.XValue); 
            ax.Maximum = points.Max(x => x.XValue); 
        }
        else if (rb_year.Checked)
        {
            setValues('y', 123);
            ax.IntervalType = DateTimeIntervalType.Months;
            ax.LabelStyle.Format = "MMMM";
            ax.Minimum = points.Min(x => x.XValue); 
            ax.Maximum = points.Max(x => x.XValue); 
        }
        s.Points.Clear();
        foreach (var dp in points)  s.Points.Add(dp);
    }
