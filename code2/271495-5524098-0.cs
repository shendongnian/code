    DataTable dt = new DataTable();
    dt.Columns.Add(new DataColumn("colBestBefore", typeof(DateTime)));
    dt.Columns.Add(new DataColumn("colStatus", typeof(string)));
    
    dt.Columns["colStatus"].Expression = String.Format("IIF(colBestBefore < #{0}#, 'Ok','Not ok')", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
    
    dt.Rows.Add(DateTime.Now.AddDays(-1));
    dt.Rows.Add(DateTime.Now.AddDays(1));
    dt.Rows.Add(DateTime.Now.AddDays(2));
    dt.Rows.Add(DateTime.Now.AddDays(-2));
    
    demoGridView.DataSource = dt;
