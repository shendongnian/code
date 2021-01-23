    public List<int> GetCounts(string connectionString)
    {
       List<int> results = new List<int>();
       string sqlStmt = "SELECT DISTINCT COUNT(Grouping) from Attendance";
 
       using(SqlConnection conn = new SqlConnection(connectionString))
       using(SqlCommand cmd = new SqlCommand(sqlStmt, conn))
       {
          conn.Open();
          using(SqlDataReader rdr = cmd.ExecuteReader())
          {
              while(rdr.Read())
              {
                  int count = rdr.GetInt32(0);  // read item no. 0 from the reader, as INT
                  results.Add(count);
              }  
              rdr.Close();
          }
          conn.Close();
       }
       return results;
    }
