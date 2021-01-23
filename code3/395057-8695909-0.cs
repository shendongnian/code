    public DataTable getReportByDate(DateTime startDate, DateTime endDate)
    {
        DataTable table = new DataTable();
    
        string sqlStmt =  
            "SELECT * FROM [dbo].[Transaction] " + 
            "WHERE CAST(CurrDate AS DATE) >= @startDate " + 
            "AND CAST(CurrDate AS DATE) <= @endDate";
          using (SqlConnection connection = new SqlConnection(connectionString))
          using (SqlCommand cmd = new SqlCommand(sqlStmt, connection))
          {
             cmd.Parameters.Add("@startDate", SqlDbType.Date).Value = startDate.Date;
             cmd.Parameters.Add("@endDate", SqlDbType.Date).Value = endDate.Date;
             SqlDataAdapter adapter = new SqlDataAdapter(cmd);
             adapter.Fill(table);
          }
          return table;
       }
    }
