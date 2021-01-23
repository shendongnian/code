    public static IDataReader GetReader(this IDbConnection conn,string query, params object[] values) {
      var Command=conn.CreateCommand();
      var paramNames=Enumerable.Range(1,values.Length).Select(i=>string.Format("@param{0}",i)).ToArray();
      Command.CommandText=string.Format(query,paramNames);
      for (var i=0;i<values.Length;i++) {
        var param=Command.CreateParameter();
        param.ParameterName=paramNames[i];
        param.Value=values[i];
        Command.Parameters.Add(param);
      }
      return Command.ExecuteReader();
    }
