    SysDraw.Color blueStart = SysDraw.Color.FromArgb(124,195,215);
    SysDraw.Color blueEnd = SysDraw.Color.FromArgb(74,166,192);
    
    SysDraw.Color grayStart = SysDraw.Color.FromArgb(153,153,153);
    SysDraw.Color grayEnd = SysDraw.Color.FromArgb(208,210,211);
    
    SysDraw.Color orangeStart = SysDraw.Color.FromArgb(252,165,107);
    SysDraw.Color orangeEnd = SysDraw.Color.FromArgb(255,104,4);
    
    void Main()
    {
    	//chart1 is from Microsoft's sample site
    	// other charts are using http://msdn.microsoft.com/en-us/library/dd489237.aspx 
    	Chart chart1 = createChart1();
    	Chart chart2=	createChart2(42, "Chart 2");
    	Chart chart3 = createChart2(99, "Chart 3");
    	Chart chart4 = createChart2(11, "Chart 4");
    
    	drawIt(chart2, chart2.Name);
    	drawIt(chart3, chart3.Name);
    	drawIt(chart4, chart4.Name);
    	drawIt(chart1, chart1.Name);
    }
    
    private void drawIt(Chart drawChart, string name)
    {
    	System.IO.MemoryStream ms = new System.IO.MemoryStream();
    	drawChart.SaveImage(ms,SysDraw.Imaging.ImageFormat.Png);
    	SysDraw.Bitmap outImage = new SysDraw.Bitmap(ms);
    	outImage.Dump(name);
    }
    private void drawIt(string imageFilePath)
    {
    	System.IO.MemoryStream ms = new System.IO.MemoryStream();
    	
    	SysDraw.Bitmap outImage = new SysDraw.Bitmap(imageFilePath);
    	outImage.Dump(imageFilePath);
    }
    
    private Chart createChart2(double dataPointYvalue, string chartName)
    {
    	string chartAreaName ="Area 1";
    
    	// Chart
    	// --------------------------------
    	Chart results = new Chart();
    	results.Name = chartName;
    	results.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
    	results.BorderSkin.SkinStyle = BorderSkinStyle.None;
    	SysDraw.Size size1 = new SysDraw.Size(480,30);
    	results.Size = size1;
    	
    	// ChartAreas collection
    	// --------------------------------
    	ChartArea area1 =new ChartArea(chartAreaName);
    	area1.Area3DStyle.Enable3D=false;
    	//area1.Area3DStyle.Enable3D=true;
    	area1.Area3DStyle.WallWidth=10;
    	//area1.Area3DStyle.Inclination=10;
    	//area1.Area3DStyle.Perspective = 10;
    	area1.Area3DStyle.Rotation=1;
    	
    	//area1.BorderDashStyle = ChartDashStyle.DashDot;
    
    	area1.BackGradientStyle = GradientStyle.TopBottom;
    	area1.BackColor = grayStart;
    	area1.BackSecondaryColor = grayEnd;
    	
    	
    	// 		Axes under Area collection
    	Axis axisX = new Axis();
    	axisX.LabelStyle.Interval = 1;
    	axisX.Title ="x axis";
    	axisX.IsMarginVisible=false;
    	axisX.Enabled = AxisEnabled.False;
    	
    	
    	
    	Axis axisY = new Axis();
    	axisY.Title = "y axis";
    	axisY.IsMarginVisible=true;
    	axisY.Enabled = AxisEnabled.False;
    	
    	area1.AxisX = axisX;
    	area1.AxisY = axisY;
    	results.ChartAreas.Add(area1);
    
    	// Series Collection Editor
    	// --------------------------------
    	Series series1 = new Series("Series 1");
    	series1.ChartArea = chartAreaName;
    	series1.ChartType = SeriesChartType.Bar;
    	series1.CustomProperties="DrawingStyle=Cylinder";
    	series1.Name = "BarChart";
    	
    	series1.BackGradientStyle = GradientStyle.TopBottom;
    	series1.Color=blueStart;
    	series1.BackSecondaryColor = blueEnd;
    	
    //	series1.BorderDashStyle= ChartDashStyle.DashDotDot;
    //	series1.BorderColor = SysDraw.Color.Red;
    	
    	//series1.Points.AddY(42);
    	DataPoint dp = new DataPoint();
    	dp.Name="MyPoint";
    	dp.YValues= new double[]{dataPointYvalue};
    	series1.Points.Add(dp);
    	results.Series.Add(series1);
    	
    	// Legend
    	// --------------------------------
    //	Legend legend = new Legend("Chart 2 Legend");
    //	legend.DockedToChartArea = "Chart 2 Area 1";
    //	legend.Docking = Docking.Right;
    //	legend.IsDockedInsideChartArea = true;
    
    //	results.Legends.Add(legend);
    	
    //	series1.Legend = "Chart 2 Legend"; //You can assign each series to a different legend.
    	
    	// Title
    	// --------------------------------
    	Title title = new Title(string.Format("Your whatever is {0}",dp.YValues[0]));
    	title.Docking = Docking.Right;
    	title.TextOrientation = TextOrientation.Horizontal;
    	//title.DockedToChartArea = chartAreaName;
    	//results.Titles.Add(title);
    	
    	// Annotations
    	// --------------------------------
    	ArrowAnnotation arrowAnnt = new ArrowAnnotation();
    	arrowAnnt.AnchorDataPoint=dp;
    	arrowAnnt.Height=-5;
    	arrowAnnt.Width=0;
    	arrowAnnt.AnchorOffsetY=-2.5;
    	arrowAnnt.SmartLabelStyle.IsOverlappedHidden = false;
    	
    	TextAnnotation textAnnt = new TextAnnotation();
    	textAnnt.AnchorDataPoint = dp;
    	textAnnt.AnchorOffsetX = -10;
    	textAnnt.ForeColor=SysDraw.Color.White;
    	textAnnt.Text = dp.YValues[0].ToString();
    	
    	//results.Annotations.Add(arrowAnnt);
    	results.Annotations.Add(textAnnt);
    	return results;
    }
    private Chart createChart1()
    		{
    			
    			Title title1 = new Title();
    			ChartArea chartArea1 = new ChartArea();
    			Legend legend1 = new Legend();
    						
    			Series series1 = new Series();
    			DataPoint dataPoint1 = new DataPoint(0, 6);
    			DataPoint dataPoint2 = new DataPoint(0, 9);
    			DataPoint dataPoint3 = new DataPoint(0, 5);
    			DataPoint dataPoint4 = new DataPoint(0, 7.5);
    			DataPoint dataPoint5 = new DataPoint(0, 5.6999998092651367);
    			DataPoint dataPoint6 = new DataPoint(0, 7);
    			DataPoint dataPoint7 = new DataPoint(0, 8.5);
    			Series series2 = new Series();
    			DataPoint dataPoint8 = new DataPoint(0, 6);
    			DataPoint dataPoint9 = new DataPoint(0, 9);
    			DataPoint dataPoint10 = new DataPoint(0, 2);
    			DataPoint dataPoint11 = new DataPoint(0, 7);
    			DataPoint dataPoint12 = new DataPoint(0, 3);
    			DataPoint dataPoint13 = new DataPoint(0, 5);
    			DataPoint dataPoint14 = new DataPoint(0, 8);
    			Series series3 = new Series();
    			DataPoint dataPoint15 = new DataPoint(0, 4);
    			DataPoint dataPoint16 = new DataPoint(0, 2);
    			DataPoint dataPoint17 = new DataPoint(0, 1);
    			DataPoint dataPoint18 = new DataPoint(0, 3);
    			DataPoint dataPoint19 = new DataPoint(0, 2);
    			DataPoint dataPoint20 = new DataPoint(0, 3);
    			DataPoint dataPoint21 = new DataPoint(0, 5);
    			Chart results = new Chart();
    			//((System.ComponentModel.ISupportInitialize)(results)).BeginInit();
    			// 
    			// resulting chart
    			// 
    			results.BackColor = System.Drawing.Color.WhiteSmoke;
    			results.BackGradientStyle = GradientStyle.TopBottom;
    			results.BackSecondaryColor = System.Drawing.Color.White;
    			results.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
    			results.BorderlineDashStyle = ChartDashStyle.Solid;
    			results.BorderlineWidth = 2;
    			results.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
    			chartArea1.Area3DStyle.Enable3D = true;
    			chartArea1.Area3DStyle.Inclination = 15;
    			chartArea1.Area3DStyle.IsClustered = false;
    			chartArea1.Area3DStyle.IsRightAngleAxes = false;
    			chartArea1.Area3DStyle.PointGapDepth = 0;
    			chartArea1.Area3DStyle.Rotation = 10;
    			chartArea1.Area3DStyle.WallWidth = 0;
    			chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
    			chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
    			chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
    			chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
    			chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
    			chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
    			chartArea1.BackColor = System.Drawing.Color.WhiteSmoke;
    			chartArea1.BackSecondaryColor = System.Drawing.Color.White;
    			chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
    			chartArea1.Name = "Default";
    			chartArea1.ShadowColor = System.Drawing.Color.Transparent;
    			results.ChartAreas.Add(chartArea1);
    			results.Cursor = System.Windows.Forms.Cursors.Hand;
    			legend1.BackColor = System.Drawing.Color.Transparent;
    			legend1.Enabled = false;
    			legend1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
    			legend1.IsTextAutoFit = false;
    			legend1.Name = "Default";
    			results.Legends.Add(legend1);
    			results.Location = new System.Drawing.Point(16, 53);
    			results.Name = "chart1";
    			series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
    			series1.ChartArea = "Default";
    			series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(65)))), ((int)(((byte)(140)))), ((int)(((byte)(240)))));
    			series1.Legend = "Default";
    			series1.Name = "Default";
    			series1.Points.Add(dataPoint1);
    //			series1.Points.Add(dataPoint2);
    //			series1.Points.Add(dataPoint3);
    //			series1.Points.Add(dataPoint4);
    //			series1.Points.Add(dataPoint5);
    //			series1.Points.Add(dataPoint6);
    //			series1.Points.Add(dataPoint7);
    //			series2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
    //			series2.ChartArea = "Default";
    //			series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(252)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
    //			series2.Legend = "Default";
    //			series2.Name = "Series2";
    //			series2.Points.Add(dataPoint8);
    //			series2.Points.Add(dataPoint9);
    //			series2.Points.Add(dataPoint10);
    //			series2.Points.Add(dataPoint11);
    //			series2.Points.Add(dataPoint12);
    //			series2.Points.Add(dataPoint13);
    //			series2.Points.Add(dataPoint14);
    //			series3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
    //			series3.ChartArea = "Default";
    //			series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(224)))), ((int)(((byte)(64)))), ((int)(((byte)(10)))));
    //			series3.Legend = "Default";
    //			series3.Name = "Series3";
    //			series3.Points.Add(dataPoint15);
    //			series3.Points.Add(dataPoint16);
    //			series3.Points.Add(dataPoint17);
    //			series3.Points.Add(dataPoint18);
    //			series3.Points.Add(dataPoint19);
    //			series3.Points.Add(dataPoint20);
    //			series3.Points.Add(dataPoint21);
    			results.Series.Add(series1);
    //			results.Series.Add(series2);
    //			results.Series.Add(series3);
    			results.Size = new System.Drawing.Size(412, 296);
    			results.TabIndex = 1;
    			title1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold);
    			title1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
    			title1.Name = "Title1";
    			title1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
    			title1.ShadowOffset = 3;
    			title1.Text = "3D Cylinder";
    			results.Titles.Add(title1);
    			
    
    			SysDraw.Size mySize = new SysDraw.Size(480, 170);
    			results.Size = mySize;
    
    			return results;
    		}
