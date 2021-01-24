        // It seems, DbQueryToList<T> is a better name 
        public static List<string> DbQueryToArray<T>() {
          //TODO: do not hardcode connection string, but read it (say, from settings)
          string SqlCString = "connString";
          //DONE: wrap IDisposable into using 
          using (SqlConnection connection = new SqlConnection(SqlCString)) {
            connection.Open();
            //DONE: keep sql readable
            string sql = 
              @"select CLIENTNO, 
                       ACCOUNT_Purpose 
                  from audit.ACCOUNTS_AUDIT";
            //DONE: wrap IDisposable into using
            using (SqlCommand command = new SqlCommand(sql, connection)) {
              //DONE: wrap IDisposable into using
              using (SqlDataReader reader = command.ExecuteReader()) {
                List<T> result = new List<T>();
                while (reader.Read())
                  result.Add(Convert.ToString(reader[0]));
                return result;  
              } 
            }   
          } 
         }
