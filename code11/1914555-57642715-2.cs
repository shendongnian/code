    private void rb_range_CheckedChanged(object sender, EventArgs e)
    {
        Chart chart = chart8;
        Series s = chart.Series[0];
        s.ChartType = SeriesChartType.Line;
        s.XValueType = ChartValueType.DateTime;
        s.YValueType = ChartValueType.Double;
        Axis ax = chart.ChartAreas[0].AxisX;
        Axis ay = chart.ChartAreas[0].AxisY;
        //ax.IsMarginVisible = true;  // max or may be necessary
        ax.Interval = 1;
        if (rb_week.Checked)
        {
            setValues('w', 123);
            ax.IntervalType = DateTimeIntervalType.Days;
            ax.LabelStyle.Format = "dddd";
        }
        else if (rb_month.Checked)
        {
            setValues('m', 123);
            ax.IntervalType = DateTimeIntervalType.Days;
            ax.LabelStyle.Format = "dd";
        }
        else if (rb_year.Checked)
        {
            setValues('y', 123);
            ax.IntervalType = DateTimeIntervalType.Months;
            ax.LabelStyle.Format = "MMMM";
        }
        s.Points.Clear();
        foreach (var dp in points)  s.Points.Add(dp);
        // after the points are added or bound to you may want to..
        // set the minimum&maximum, but if the data fit you don't have to!
        ax.Minimum = points.Min(x => x.XValue); 
        ax.Maximum = points.Max(x => x.XValue); 
    }
