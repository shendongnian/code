    private void FillChart()
    {
        // register the format event
        this.chart1.FormatNumber += new EventHandler<FormatNumberEventArgs>(chart1_FormatNumber);
    
        // fill the data table with values
        DataTable dt = new DataTable();
        dt.Columns.Add("X", typeof(DateTime));
        dt.Columns.Add("Y", typeof(double));
    
        dt.Rows.Add(DateTime.Today.AddDays(1), 10);
        dt.Rows.Add(DateTime.Today.AddDays(8), 30);
        dt.Rows.Add(DateTime.Today.AddDays(15), 10);
        dt.Rows.Add(DateTime.Today.AddDays(21), 20);
        dt.Rows.Add(DateTime.Today.AddDays(25), 40);
        dt.Rows.Add(DateTime.Today.AddDays(31), 25);
    
        // bind the data table to chart
        this.chart1.Series.Clear();
    
        var series = this.chart1.Series.Add("Series 1");
        series.XValueMember = "X";
        series.YValueMembers = "Y";
    
        series.ChartType = SeriesChartType.Line;
        this.chart1.DataSource = dt;
        this.chart1.DataBind();
    
        // set a custom format to recognize the AxisX label in the event handler
        this.chart1.ChartAreas[0].AxisX.LabelStyle.Format = "CustomAxisXFormat"; 
    
    }
    
    void chart1_FormatNumber(object sender, FormatNumberEventArgs e)
    {
        if (e.ElementType == ChartElementType.AxisLabels &&
            e.Format == "CustomAxisXFormat")
        {
            if (e.ValueType == ChartValueType.DateTime)
            {
                var currentCalendar = CultureInfo.CurrentCulture.Calendar;
                e.LocalizedValue = "CW" +
                    currentCalendar.GetWeekOfYear(DateTime.FromOADate(e.Value),
                    System.Globalization.CalendarWeekRule.FirstDay,
                    CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);
            }
        }
    }
