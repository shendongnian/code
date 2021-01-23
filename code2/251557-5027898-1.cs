    public int ExecuteScalar(string commandText, IDataParameter[] param)
          {
             IDbCommand cmd = connection.CreateCommand();
             cmd.CommandText = commandText;
             foreach (IDataParameter p in param)
                cmd.Parameters.Add(p);
          }
