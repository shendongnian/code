    static string connectionString = ConfigurationManager.AppSettings["MessageDB"].ToString();
    public static void Message(MessageLog messageLog)
    {
       using(var _sqlconn = new SqlConnection(connectionString))
       {
          using(var cmd = new SqlCommand())
          {
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.CommandText = "INSERT_MESSAGE";
              cmd.Connection = _sqlconn;
              cmd.Parameters.Add("@MessageID", DbType.Int16).Value = messageLog.MessageID;
              try
              {
                  if(_sqlconn.State == ConnectionState.Closed) _sqlconn.Open()
                  
                  cmd.ExecuteNonQuery();
                  
              }
              catch (Exception ex)
              {
                   ExceptionLogger.LogException(ex);
              } 
              finally
              { 
                   if (_sqlconn.State == ConnectionState.Open)
                   {
                      _sqlconn.Close();
                   }
              }
          }
       }
    }       
