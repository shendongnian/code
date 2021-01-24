    // wrap IDisposable into using
    using (SqlConnection con = new SqlConnection("***COnString**")) {
      con.Open();
      //DONE: Make sql readable
      //DONE: Make sql parametrized
      //TODO: you may want to change eb_number = eb_number into INNER JOIN
      string sql = 
        @"SELECT SUM (Total_Hours_Day) 
            FROM Sign_In_Out_Table, 
                 User_Table 
           WHERE User_Table.FirstName = @prm_FirstName  
             AND Sign_In_Out_Table.eb_number = User_Table.eb_number 
             AND Date BETWEEN GETDATE() - 14 AND GETDATE()"; 
      using (SqlCommand comm = new SqlCommand(sql, con)) {
        //TODO: Better specify RDBMS type explictly with "comm.Parameters.Add(...)"
        comm.Parameters.AddWithValue(
          "@prm_FirstName", Search_Username_Alerts_Admin_txtbox.Text); 
        var result = comm.ExecuteScalar();
        if (null == result) {              // No Data
          MessageBox.Show("No Data Exist");
        }
        else if (DBNull.Value == result) { // We have the Data and it's RDBMS Null
          MessageBox.Show("Data Exist, but not valid.");
        } 
        else {                             // We have a valid Decimal
          Decimal sum = Convert.ToDecimal(result); 
          //TODO: put the relevant code here
        }
      }
    }
