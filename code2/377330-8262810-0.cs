    private void FillChart()
    {
        var dt = new DataTable();
        dt.Columns.Add("X", typeof(double));
        dt.Columns.Add("Y", typeof(double));
    
        dt.Rows.Add(1, 3);
        dt.Rows.Add(2, 7);
        dt.Rows.Add(3, 2);
        dt.Rows.Add(4, 1);
        dt.Rows.Add(5, 5);
        dt.Rows.Add(6, 9);
        dt.Rows.Add(7, 0);
    
        this.chart1.Series.Clear();
    
        this.chart1.DataSource = dt;
        var series = this.chart1.Series.Add("MYSERIES");
        series.XValueMember = "X";
        series.YValueMembers = "Y";
    
        // set a custom minimum and maximum
        chart1.ChartAreas[0].AxisY.Minimum = -10;
        chart1.ChartAreas[0].AxisY.Maximum = 10;
    
        chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
        chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
        chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true; 
    }
