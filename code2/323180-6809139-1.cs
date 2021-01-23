    public static bool addData(string storedProcName, string[] dynamicParamName, object[] paramVals, string msg)
    {
        SqlParameter[] paramArr = new SqlParameter[dynamicParamName.Length];
        for(int i = 0; i < dynamicParamName.Length; i++)
        {
            paramArr[i] = new SqlParameter(dynamicParamName[i], paramVals[i]);
        }
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = connection.CreateCommand())
        {
            command.CommandText = commandText;
            //command.CommandType = CommandType.StoredProcedure ; // if needed
            command.Parameters.AddRange(paramArr);
            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }
    }
