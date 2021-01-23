    DataTable dt = new DataTable(); 
    //fill the dt here 
    DataTable dt2 = new DataTable(); 
    string[] strCols = {"Column Name to copy"}; 
    dt2 = dt.DefaultView.ToTable("newTableName", false, strCols);
