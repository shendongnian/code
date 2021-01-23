	const int NumberOfBars = 5;
	GraphPane myPane = zedGraphControl1.GraphPane;
	myPane.Title.Text = "Employee Hours";
	myPane.BarSettings.Type = BarType.Stack;
	myPane.BarSettings.ClusterScaleWidth = 1D;
	// X AXIS SETTINGS
	myPane.XAxis.Title.Text = "Date";
	myPane.XAxis.Type = AxisType.Date;
	myPane.XAxis.Scale.Format = "dd-MMM-yy";
	myPane.XAxis.Scale.MajorUnit = DateUnit.Day;
	myPane.XAxis.Scale.MajorStep = 1;
	myPane.XAxis.Scale.Min = new XDate(DateTime.Now.AddDays(-NumberOfBars));
	myPane.XAxis.Scale.Max = new XDate(DateTime.Now);
	myPane.XAxis.MajorTic.IsBetweenLabels = true;
	myPane.XAxis.MinorTic.Size = 0;
	myPane.XAxis.MajorTic.IsInside = false;
	myPane.XAxis.MajorTic.IsOutside = true;
	// Y AXIS SETTINGS
	myPane.YAxis.Title.Text = "Hours Worked";
	myPane.YAxis.Type = AxisType.Linear;
	myPane.YAxis.Scale.Format = @"00:\0\0";
	myPane.YAxis.Scale.Min = 0;
	myPane.YAxis.Scale.Max = 24;
	myPane.YAxis.Scale.MajorStep = 1;
	myPane.YAxis.MinorTic.Size = 0;
	// Construct some sample data
	Random r = new Random();
	List<double> DatesX = new List<double>();
	double[] JohnHours = new double[NumberOfBars];
	double[] JoanHours = new double[NumberOfBars];
	double[] JaneHours = new double[NumberOfBars];
	for (int i = 0; i < NumberOfBars; i++)
	{
		DatesX.Add(new XDate(DateTime.Today.AddDays(-i)));
		JohnHours[i] = r.Next(1, 9);
		JoanHours[i] = r.Next(1, 9);
		JaneHours[i] = r.Next(1, 9);
	}
	myPane.AddBar("John", DatesX.ToArray(), JohnHours, Color.Red);
	myPane.AddBar("Joan", DatesX.ToArray(), JoanHours, Color.Blue);
	myPane.AddBar("Jane", DatesX.ToArray(), JaneHours, Color.Green);
