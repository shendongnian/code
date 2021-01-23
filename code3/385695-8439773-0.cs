    SqlCeCommand oCommand = conn.CreateCommand();
    oCommand.CommandText = "insert into contacts(name, emails) values(?, ?)";
    // I can't remember if the param names need @ or not
    oCommand.Parameters.Add("@name", SqlDbType.VarChar);
    oCommand.Parameters.Add("@email", SqlDbType.VarChar);
    
    SqlCeTransaction oTrans = conn.BeginTransaction();
    try {
      foreach (KeyValuePair<string, string> key in list) {
         oCommand.Parameters[0].Value = key.Key;
         oCommand.Parameters[1].Value = key.Value;
         oCommand.ExecuteNonQuery();
      }
      oTrans.Commit();
    } catch (Exception ex) {
      oTrans.Rollback();
    }
