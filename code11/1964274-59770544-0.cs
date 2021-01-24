`
protected void Page_Load(Object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[5] { new DataColumn("Period/Month", typeof(double)),
                            new DataColumn("Periodic Payment", typeof(double)),
                            new DataColumn("Intrest Payment", typeof(double)),
                            new DataColumn("Principal Payment", typeof(double)),
                            new DataColumn("Principal Balance",typeof(double)) });
        for (int i = 0; i < 10; i++)
        {
            DataRow row = dt.NewRow();
            row[0] = "1";
            row[1] = "2";
            row[2] = "3";
            row[3] = "4";
            row[4] = "5";
            dt.Rows.Add(row);
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
`
