    System.Windows.Forms.DataVisualization.Charting.Chart chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
    System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
    System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
    System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
    System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(36890, 32);
    System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(36891, 56);
    System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(36892, 35);
    System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(36893, 12);
    System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(36894, 35);
    System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(36895, 6);
    System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint7 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(36896, 23);
    System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
    System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
    
    chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
    chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
    chart1.BorderlineWidth = 2;
    chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
    
    chartArea1.Area3DStyle.Inclination = 15;
    chartArea1.Area3DStyle.IsClustered = true;
    chartArea1.Area3DStyle.IsRightAngleAxes = false;
    chartArea1.Area3DStyle.Perspective = 10;
    chartArea1.Area3DStyle.Rotation = 10;
    chartArea1.Area3DStyle.WallWidth = 0;
    chartArea1.AxisX.LabelAutoFitMaxFontSize = 8;
    chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
    chartArea1.AxisX.LabelStyle.Format = "MM-dd";
    chartArea1.AxisX.LabelStyle.IsEndLabelVisible = false;
    chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
    chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
    chartArea1.AxisY.LabelAutoFitMaxFontSize = 8;
    chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
    chartArea1.AxisY.LabelStyle.Format = "C0";
    chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
    chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
    chartArea1.BackColor = System.Drawing.Color.OldLace;
    chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
    chartArea1.BackSecondaryColor = System.Drawing.Color.White;
    chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
    chartArea1.Name = "Default";
    chartArea1.ShadowColor = System.Drawing.Color.Transparent;
    
    chart1.ChartAreas.Add(chartArea1);
    
    legend1.BackColor = System.Drawing.Color.Transparent;
    legend1.Enabled = false;
    legend1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
    legend1.IsTextAutoFit = false;
    legend1.Name = "Default";
    
    chart1.Legends.Add(legend1);
    chart1.Location = new System.Drawing.Point(16, 64);
    chart1.Name = "chart1";
    
    series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
    series1.ChartArea = "Default";
    series1.Legend = "Default";
    series1.Name = "Series1";
    series1.Points.Add(dataPoint1);
    series1.Points.Add(dataPoint2);
    series1.Points.Add(dataPoint3);
    series1.Points.Add(dataPoint4);
    series1.Points.Add(dataPoint5);
    series1.Points.Add(dataPoint6);
    series1.Points.Add(dataPoint7);
    series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
    
    chart1.Series.Add(series1);
    chart1.Size = new System.Drawing.Size(412, 296);
    chart1.TabIndex = 0;
    
    title1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold);
    title1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
    title1.Name = "Title1";
    title1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
    title1.ShadowOffset = 3;
    title1.Text = "Column Chart";
    
    chart1.Titles.Add(title1);
