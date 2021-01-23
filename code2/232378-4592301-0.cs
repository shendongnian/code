    public static DataTable GetDataTable(SqlCommand sqlCmd)
    {
        DataTable tblMyTable = new DataTable();
        try
        {
            // Create connection
            using(SqlConnection mSqlConnection = new SqlConnection(mStrConnection))
            {
               // Assign Connection   
               sqlCmd.Connection = mSqlConnection;
               // Create/Set DataAdapter
              using(SqlDataAdapter mSqlDataAdapter = new SqlDataAdapter(sqlCmd))
              {
                  mSqlDataAdapter.Fill(tblMyTable);
              }
            }
         }
        catch (Exception ex)
        {
           // handle exception
        }
        // Return DataTable
        return tblMyTable;
    }
