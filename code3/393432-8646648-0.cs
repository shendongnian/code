      string sqlIn = "1,2,3,4,5";
      string inParams = sqlIn.Split(',');
      List<string> paramNames = new List<string>();
      for(var i = 0; i < inParams.Length; ++i){
            string paramName = "@param" + i.ToString();
            SqlCeCommand cmd.Parameters.Add(paramName, SqlDbType.Int).Value = int.Parse(inParams);
            paramNames.Add(paramName);
      }
      string sql = "... WHERE [personID] IN (" +
          string.Join(",", paramNames) +
          ") ...";
