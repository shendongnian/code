    string selectedDate = compareDate.ToString("yyyy/MM/dd");   
    
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginDBConnectionString1"].ConnectionString);
        SqlCommand com = new SqlCommand("SELECT * from Holiday where Date='" + selectedDate + "'", conn);
        SqlDataAdapter sqlDa = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sqlDa.Fill(dt);
    
    if (dt == null || dt.Rows.Count() == 0)
        return "NG";
    else
        return "OK";
        
