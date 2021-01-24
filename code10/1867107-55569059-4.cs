    for (int i = 0; i < users.Count; i++)
    {
        Series s = chart1.Series.Add(users[i]);
        s.ChartType = SeriesChartType.Line;
        BindingSource bs = new BindingSource();
        bs.DataSource = dt;
        bs.Filter = "User='" + users[i] + "'";
        s.Points.DataBindXY(bs, "Date", bs, "Value");
    }
