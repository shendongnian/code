    ay.LabelStyle.Angle = 0;
    ay.IsLabelAutoFit = true;
    DateTime d1 = DateTime.FromOADate(ay.Minimum);
    DateTime d2 = DateTime.FromOADate(ay.Maximum);
    int dc = (int)(d2 - d1).TotalDays;
    //double dspace = d2.ToOADate() - d1.ToOADate();  // we need a suitable number later (*)
    dspace = 10;    // seems to work better when zooming in..
    for (int i = 0; i < dc; i++)
    {
        DateTime dt = d1.AddDays(i);
        double dd = dt.ToOADate();
        CustomLabel cl = new CustomLabel();
        cl.Text = dt.Day + "";
        cl.FromPosition = dd - dspace;  //(*)
        cl.ToPosition = dd + dspace;   //(*)
        cl.RowIndex = 0;              // 1st row of labels
        ay.CustomLabels.Add(cl);
        if (dt.Day == 1)  // place month name at the 1st day
        {
            cl = new CustomLabel();
            string month = d1.AddDays(i).ToString("MMMM");
            cl.Text = month;
            cl.FromPosition = dd - dspace;  //(*)
            cl.ToPosition = dd + dspace;   //(*)
            cl.RowIndex = 1;              // 2nd row
            ay.CustomLabels.Add(cl);
        }
    }
