        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        da.Fill(ds);
        DataTable dt = ds.Tables[0];
        DataColumn dc = new DataColumn("TIME", typeof(System.DateTime));
        dc.DefaultValue = dataTimePicker.SelectedDate;
        dt.Columns.Add(dc);
        grdView.DataSource = dt;
        grdView.DataBind();
    
