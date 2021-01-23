    public void DuesChartLoad()
    {
        string prjid = Request.QueryString[0].ToString();
        DataSet ds = objbug.GetBugDetails(prjid);
        ViewState["Dues"] = ds;
        DateTime now = DateTime.Now;
        DataTable dt = ds.Tables[0];
        
        string[] x = new string[dt.Rows.Count];
        int[] y = new int[dt.Rows.Count];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            x[i] = dt.Rows[i][0].ToString();
            y[i] = Convert.ToInt32(dt.Rows[i][1]);
  
        }
        
         DuesChart.Series[0].Points.DataBindXY(x, y);
         DuesChart.Series[0].Points.DataBindXY(x, y);
       //  DuesChart.Series[0].Color=System.Drawing.Color.Red;
         DuesChart.Series[0].BorderWidth = 10;
        DuesChart.Series[0].Points.DataBindXY(x,y);
        #region cannot working
        //Color[] colors = new Color[] { Color.Red, Color.Green, Color.Wheat, Color.Gray, Color.AliceBlue,Color.Pink,Color.Black,Color.Beige };
        //foreach (Series series in DuesChart.Series)
        //{
        //    foreach (DataPoint point in series.Points)
        //    {
        //        //Set color for the bar
        //        point.LabelBackColor = colors[series.Points.IndexOf(point)];
        //    }
        //}
