    List<double> yValues = new List<double>();
    List<string> xValues = new List<string>();
    List<int> zValues = new List<int>();
    // First and Last columns do not contain chartable data
    for (int i = 1; i < dtResults.Columns.Count - 1; i++) {
    	double d;
    	if (double.TryParse(dtResults.Rows[1][i].ToString(), out d))
    		yValues.Add(d == 0 ? double.NaN : d);
    	else
    		yValues.Add(double.NaN);
    } // foreach of the Average Time Values the chart
    // foreach of the column names
    for (int i = 1; i < dtResults.Columns.Count - 1; i++)
    	xValues.Add(dtResults.Columns[i].ColumnName);
    this.Chart.Titles["Title1"].Text = string.Format(
    	"Average Request Time In Seconds On {0:MM/dd/yyyy} Between {1:HH} and {2:HH} In {3}",
    	this.DateRange.BeginDate.Value,
    	this.ucsTimePicker.BeginTime,
    	this.ucsTimePicker.EndTime,
    	this.SelectedSourceEnvironmentName
    );
    this.Chart.Series["Series1"].Points.DataBindXY(xValues, yValues);
    /// This loop will setup the point labels in a two line format where the first line displays
    /// the Average that the point is actually showing.  The second line is data taken from the
    /// results table and is not a part of the chart at all but is useful information and is the
    /// Count of records in that time frame.
    /// In order for this to work, the Series property IsValueShownAsLabel needs to be NOT True.
    for (int i = 0; i < this.Chart.Series["Series1"].Points.Count; i++) {
    	int n = 0;
    	int.TryParse(dtResults.Rows[0][i + 1].ToString(), out n);
    	this.Chart.Series["Series1"].Points[i].Label = string.Format("Avg: #VALY{{0.000}}\nCount: {0}", n);
    } // foreach of the Count of Request within the Hour values
    this.Chart.Series["Series1"].ChartType = SeriesChartType.Line;
    this.Chart.Series["Series1"]["ShowMarkerLines"] = "true";
    this.Chart.ChartAreas["ChartArea1"].AxisX.IsMarginVisible = true;
    this.Chart.ChartAreas["ChartArea1"].AxisX.Title = "Hours of the Day";
    this.Chart.ChartAreas["ChartArea1"].AxisY.Title = "Time in Seconds";
    // Handle styling when there is a Zero or missing value
    this.Chart.Series["Series1"].EmptyPointStyle.Color = Color.Red;
    this.Chart.Series["Series1"].EmptyPointStyle.BorderWidth = 3;
    this.Chart.Series["Series1"].EmptyPointStyle.BorderDashStyle = ChartDashStyle.Dash;
    this.Chart.Series["Series1"].EmptyPointStyle.MarkerStyle = MarkerStyle.Diamond;
    this.Chart.Series["Series1"].EmptyPointStyle.MarkerColor = Color.Red;
    this.Chart.Series["Series1"].EmptyPointStyle.MarkerSize = 8;
    this.Chart.Series["Series1"].EmptyPointStyle.MarkerBorderColor = Color.Black;
    this.Chart.Series["Series1"]["EmptyPointValue"] = "Zero";
