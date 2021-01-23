    chartArea1.AxisX.MajorGrid.Enabled = false;
    chartArea1.AxisY.InterlacedColor = System.Drawing.Color.Lime;
    chartArea1.AxisY.LabelStyle.Format = "T";
    chartArea1.AxisY.MajorGrid.Enabled = false;
    chartArea1.Name = "ChartArea1";
    this.chart1.ChartAreas.Add(chartArea1);
    this.chart1.Location = new System.Drawing.Point(0, 0);
    this.chart1.Name = "chart1";
    series1.ChartArea = "ChartArea1";
    series1.ChartType =
    System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
    series1.Color = System.Drawing.Color.White;
    series1.Name = "StartSeries";
    series2.BorderColor = System.Drawing.Color.Black;
    series2.BorderWidth = 2;
    series2.ChartArea = "ChartArea1";
    series2.ChartType = 
    System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
    series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte) 
    (192)))), ((int)(((byte)(0)))));
    series2.EmptyPointStyle.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), 
    ((int)(((byte)(192)))), ((int)(((byte)(0)))));
    series2.Name = "ProjectDurationSeries";
    series3.BackHatchStyle = 
    System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.ForwardDiagonal;
    series3.BackSecondaryColor = System.Drawing.Color.White;
    series3.BorderColor = System.Drawing.Color.Black;
    series3.BorderWidth = 2;
    series3.ChartArea = "ChartArea1";
    series3.ChartType = 
    System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
    series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)
    (((byte)(128)))), ((int)(((byte)(255)))));
    series3.Name = "ProjectRemainingSeries";
    series4.BackHatchStyle = 
    System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.ForwardDiagonal;
    series4.BorderColor = System.Drawing.Color.Black;
    series4.BorderWidth = 2;
    series4.ChartArea = "ChartArea1";
    series4.ChartType = 
    System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
    series4.Color = System.Drawing.Color.Red;
    series4.Name = "Series4";
    this.chart1.Series.Add(series1);
    this.chart1.Series.Add(series2);
    this.chart1.Series.Add(series3);
    this.chart1.Series.Add(series4);
    this.chart1.Size = new System.Drawing.Size(727, 339);
    this.chart1.TabIndex = 0;
    this.chart1.Text = "chart1";
