     protected void Page_Init(object sender, EventArgs e)
    {
        // Use Page_Init event Instead of Page_Load event 
       // in case of adding dynamic controls to trigger events properly
        charTest();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void charTest()
    {
        double[] yValues = { 71.15, 23.19, 5.66 };
        string[] xValues = { "AAA", "BBB", "CCC" };
        string[] xtValues = { "AAAa", "BBBa", "CCCa" };
        Chart temp1 = new Chart();
        Chart temp2 = new Chart();
        temp1.ID = "ChartArea1";
        temp1.Series.Add(new Series("Series1"));
        temp1.ChartAreas.Add(new ChartArea("ChartArea1"));
        temp1.Series["Series1"].Points.DataBindXY(xValues, yValues);
        //temp1.Load += new EventHandler(Chart1_Click);
        temp1.Series["Series1"].PostBackValue = "#VALY-#VALX";
        temp1.Click += new ImageMapEventHandler(Chart1_Click);
        PlaceHolder1.Controls.Add(temp1);
    }
    protected void Chart1_Click(object sender, ImageMapEventArgs e)
    {
        string test = e.PostBackValue;
    }
