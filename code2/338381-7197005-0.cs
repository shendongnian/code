           command.CommandText=  @"CREATE LOGIN @LoginName WITH password=@Password";
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@LoginName",
                    Value = "MyLoginNameValue",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                });
            command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Password",
                    Value = "MyPasswordValue",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50
                });
