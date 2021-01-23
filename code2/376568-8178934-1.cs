    public int CountRowsInTable()
    {
       string stmt = "SELECT COUNT(*) FROM dbo.YourTable";
       int count = 0;
       using(SqlConnection thisConnection = new SqlConnection("Data Source=DATASOURCE"))
       using(SqlCommand cmdCount = new SqlCommand(stmt, thisConnection))
       {
           thisConnection.Open();
           count = (int)cmdCount.ExecuteScalar();
           thisConnection.Close();
       }
       return count;
    }
