              SqlConnection sqlConn = new SqlConnection(data source=(local);initial catalog=bj001;user id=SA;password=bj");
              SqlCommand sqlCmd = new SqlCommand("procedureName", sqlConn);
              sqlCmd.CommandType = CommandType.StoredProcedure;
              sqlConn.Open();
              SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
              DataSet ds = new DataSet();
              sda.Fill(ds);
              sqlconn.Close();
              //retrieving individual tables from a common DataSet 
              
              DataTable dt1 = dt.Tables[0];
              DataTable dt2 = dt.Tables[1];  
              DataTable dt3 = dt.Tables[2];
              DataTable dt4 = dt.Tables[3];  
             // to display all rows of a table, we use foreach loop for each DataTable
             foreach (DataRow dr in dt1.Rows)
             Console.WriteLine("Student Name: "+dr[sName]);
