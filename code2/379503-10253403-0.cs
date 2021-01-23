    using Infragistics.Win.UltraWinChart;
    using Infragistics.UltraChart.Resources.Appearance;
    
    DataTable dt = new DataTable();
    dt.Columns.Add("Value", typeof(double));
    dt.Columns.Add("Date", typeof(DateTime));
    dt.Rows.Add(1.0, DateTime.Parse("04/20/2012"));
    dt.Rows.Add(0.5, DateTime.Parse("04/21/2012"));
    dt.Rows.Add(0.25, DateTime.Parse("04/22/2012"));
    dt.Rows.Add(0.125, DateTime.Parse("04/23/2012"));
    dt.Rows.Add(0.0625, DateTime.Parse("04/24/2012"));
    dt.Rows.Add(0.03125, DateTime.Parse("04/25/2012"));
    dt.Rows.Add(0.015625, DateTime.Parse("04/26/2012"));
    dt.Rows.Add(0.0, DateTime.Parse("04/27/2012"));
    
    NumericTimeSeries series = new NumericTimeSeries();
    series.DataBind(dt, "Date", "Value");
    
    UltraChart ultraChart = new UltraChart();
    ultraChart.Data.SwapRowsAndColumns = true;
    ultraChart.Dock = DockStyle.Fill;
    ultraChart.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.LineChart;
    ultraChart.DataSource = dt;
    
    this.Controls.Add(ultraChart);
