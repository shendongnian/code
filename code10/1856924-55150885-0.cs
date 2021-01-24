    string[] cmds = new string[3] {  sp1_SQL, sp2_SQL, sp3_SQL };
    try
    {
      foreach( string sql in cmds)
      {
         using(System.Data.SqlClient.SqlCommand command = conn.CreateCommand())
         {
           command.CommandText = sql;
           var rtn = command.ExecuteNonQuery();
         }
       }
    }
    catch(sqlException ex)
    {
      ex.message;
    }
