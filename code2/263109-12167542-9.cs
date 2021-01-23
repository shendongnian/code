    {
        SqlConnection sqlConn = new SqlConnection("data source=(local);initial catalog=bj001;user id=SA;password=bj");
        SqlCommand sqlCmd = new SqlCommand("procedureName", sqlConn);
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlConn.Open();
        SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        sqlconn.Close();
        // Retrieving total stored tables from a common DataSet.              
        DataTable dt1 = ds.Tables[0];
        DataTable dt2 = ds.Tables[1];  
        DataTable dt3 = ds.Tables[2];
        DataTable dt4 = ds.Tables[3];  
        // To display all rows of a table, we use foreach loop for each DataTable.
        foreach (DataRow dr in dt1.Rows)
        {
            Console.WriteLine("Student Name: "+dr[sName]);
        }
    }
