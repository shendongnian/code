    gridView.DataSource = dt;
    gridView.DataBind();
    
    ViewState["DownLoadGridData"]=dt as DataTable;
    
    DataTable dt =  ViewState["DownLoadGridData"] as DataTable;
    
    foreach (DataRow row in dt.Rows)
    {
        foreach (DataColumn column in dt.Columns)
        {
            if (row[FilePath] != null) // This will check the null values also (if you want to check).
            {
                   // then add filepath 
    	       string filePath = row[FilePath].ToString();
    	       zip.AddFile(filePath, ProductUrl);
    
            }
         }
    }
