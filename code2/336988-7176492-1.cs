    protected string ExecuteQuery(SqlCommand QueryObject, SqlConnection conn) { 
       try
       {
          conn.open();
          int queryResult = QueryObject.ExecuteNonQuery(); 
          if (queryResult != 0) { 
             return "Your request is CORRECT"; 
          } 
          else { 
             return "error: QueryResult= " + queryResult; 
          }
       }
       finally
       { 
          conn.close();
       }
    }
