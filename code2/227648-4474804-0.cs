        System.Data.SqlClient.SqlConnection connection 
            = new System.Data.SqlClient.SqlConnection("connection string goes here");
        System.Data.SqlClient.SqlCommand command = connection.CreateCommand();
        System.Data.SqlClient.SqlParameter parameter = command.CreateParameter();
        parameter.ParameterName = "@ParameterName";
        parameter.DbType = DbType.String;
        parameter.Value = "Some String Value";
        command.Parameters.Add(parameter);
