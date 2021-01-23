    protected void Page_Load(object sender, EventArgs e)
    {
        string[] xAxis = { "Student1", "Student2", "Student3", "Student4", "Student5", "Student6" };
        double[] yAxis = { 39, 67, 96, 86, 47, 98 };
        Chart1.Series["Legend"].Points.DataBindXY(xAxis, yAxis);
 
        Chart1.Series["Legend"].Points[0].Color = Color.Black;
        Chart1.Series["Legend"].Points[1].Color = Color.Bisque;
        Chart1.Series["Legend"].Points[2].Color = Color.Blue;
        Chart1.Series["Legend"].Points[3].Color = Color.BlueViolet;
        Chart1.Series["Legend"].Points[4].Color = Color.Brown;
        Chart1.Series["Legend"].Points[5].Color = Color.CornflowerBlue;
 
        Chart1.Series["Legend"].ChartType = SeriesChartType.Column;     
 
        Chart1.ChartAreas["studentChartArea"].Area3DStyle.Enable3D = true;       
    }
