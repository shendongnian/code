     protected void Page_Load(object sender, EventArgs e)
    {
        
        DataTable dt = new DataTable();
        dt.Columns.Add("year", typeof(string));
        dt.Columns.Add("numUsers", typeof(int));
        dt.Rows.Add(new object[] { "2005", -100 });
        dt.Rows.Add(new object[] { "2006", 160 });
        dt.Rows.Add(new object[] { "2007", -250 });
        dt.Rows.Add(new object[] { "2008", 500 });
        dt.Rows.Add(new object[] { "2009", -860 });
        dt.Rows.Add(new object[] { "2010", 600 });
        UltraChart1.Axis.X.RangeMin = -200;
        UltraChart1.Axis.X.RangeMax = 500;
        UltraChart1.Data.DataSource = dt;
        UltraChart1.ChartType = ChartType.BarChart;
        UltraChart1.Data.DataBind();
        
    }
