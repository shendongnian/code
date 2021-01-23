    Chart c = new Chart();
    c.AntiAliasing = AntiAliasingStyles.All;
    c.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
    c.Width = 640; //SET HEIGHT
    c.Height = 480; //SET WIDTH
    
    ChartArea ca = new ChartArea();
    ca.BackColor = Color.FromArgb(248, 248, 248);
    ca.BackSecondaryColor = Color.FromArgb(255, 255, 255);
    ca.BackGradientStyle = GradientStyle.TopBottom;
    
    ca.AxisY.IsMarksNextToAxis = true;
    ca.AxisY.Title = "Gigabytes Used";
    ca.AxisY.LineColor = Color.FromArgb(157, 157, 157);
    ca.AxisY.MajorTickMark.Enabled = true;
    ca.AxisY.MinorTickMark.Enabled = true;
    ca.AxisY.MajorTickMark.LineColor = Color.FromArgb(157, 157, 157);
    ca.AxisY.MinorTickMark.LineColor = Color.FromArgb(200, 200, 200);
    ca.AxisY.LabelStyle.ForeColor = Color.FromArgb(89, 89, 89);
    ca.AxisY.LabelStyle.Format = "{0:0.0}";
    ca.AxisY.LabelStyle.IsEndLabelVisible = false;
    ca.AxisY.LabelStyle.Font = new Font("Calibri", 4, FontStyle.Regular);
    ca.AxisY.MajorGrid.LineColor = Color.FromArgb(234, 234, 234);
    
    ca.AxisX.IsMarksNextToAxis = true;
    ca.AxisX.LabelStyle.Enabled = false;
    ca.AxisX.LineColor = Color.FromArgb(157, 157, 157);
    ca.AxisX.MajorGrid.LineWidth = 0;
    ca.AxisX.MajorTickMark.Enabled = true;
    ca.AxisX.MinorTickMark.Enabled = true;
    ca.AxisX.MajorTickMark.LineColor = Color.FromArgb(157, 157, 157);
    ca.AxisX.MinorTickMark.LineColor = Color.FromArgb(200, 200, 200);
    
    c.ChartAreas.Add(ca);
    
    Series s = new Series();
    s.Font = new Font("Lucida Sans Unicode", 6f);
    s.Color = Color.FromArgb(215, 47, 6);
    s.BorderColor = Color.FromArgb(159, 27, 13);
    s.BackSecondaryColor = Color.FromArgb(173, 32, 11);
    s.BackGradientStyle = GradientStyle.LeftRight;
    
    int i = 0;
    foreach (DataRow dr in sourceData.Rows)
    {
    	DataPoint p = new DataPoint();
    	p.XValue = i;
    	p.YValues = new Double[] { Convert.ToDouble(dr[0]) };
    	s.Points.Add(p);
    	i++;
    }
    
    c.Series.Add(s);
    c.SaveImage(Server.MapPath("~/output.png"), ChartImageFormat.Png);
