    internal static void FastInsertMany(DbConnection cnn)
    {
      using (DbTransaction dbTrans = cnn.BeginTransaction())
      {
        using (DbCommand cmd = cnn.CreateCommand())
        {
          cmd.CommandText = "INSERT INTO TestCase(MyValue) VALUES(?)";
    
          DbParameter Field1 = cmd.CreateParameter();
    
          cmd.Parameters.Add(Field1);
    
          for (int n = 0; n < 100000; n++)
          {
            Field1.Value = n + 100000;
            cmd.ExecuteNonQuery();
          }
        }
    
        dbTrans.Commit();
    
      }
    }
