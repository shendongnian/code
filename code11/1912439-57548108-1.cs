    // The model that describe the data returned by the query
    public class TaskData
    {
        public string Name {get;set;}
        public int Length {get;set;}
    } 
    ..... 
    // Where you store each record retrieved by the query
    List<TaskData> results = new List<TaskData>();
    using (SqlConnection con = new SqlConnection(_connectionString))
    {
       // Added the taskname to the query
       string query = @"SELECT TaskName, SUM(TaskLength) as TaskLength 
                      FROM myTable 
                      WHERE EventStartTime 
                      BETWEEN '2019/8/17' AND '2019/8/19' 
                      GROUP BY TaskName ORDER BY TaskLength";
    
       using (SqlCommand cmd = new SqlCommand(query, con))
       {
          con.Open();
          // A reader to loop over the results
          using(SqlDataReader reader = cmd.ExecuteReader())
          {
              // Start reading data (untile there are no more record to read)
              while(reader.Read())
              {
                   // From the current record build the TaskData info
                   TaskData data = new TaskData
                   {
                       Name = reader["TaskName"],
                       Length = Convert.ToInt32(reader["TaskLength "]);
                   }
                   // Add this info the the collection of your results
                   results.Add(data);
              }
          }
       }
    }
