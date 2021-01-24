    var userName = "kittoes0124";
    var email = "kittoes0124@someplace.com";
    var passwordHash = Enumerable.Range(0, 64).Select(i => ((byte)0)).ToArray();
    try {
        using (var connection = new SqlConnection("Data Source=.;Initial Catalog=HadoopUtil;Trusted_Connection=True;"))
        using (var command = connection.CreateCommand()) {
            var tableMetadata = new[] {
                new SqlMetaData("UserName", SqlDbType.NVarChar, 255),
                new SqlMetaData("Email", SqlDbType.NVarChar, 255),
                new SqlMetaData("PasswordHash", SqlDbType.VarBinary, 64),
            };
            var tableParameter = new SqlParameter("users", SqlDbType.Structured);
            var tableValues = new SqlDataRecord(tableMetadata);
            tableParameter.TypeName = "[dbo].[ISSUser]";
            tableParameter.Value = new[] { tableValues };
            tableValues.SetValue(0, userName);
            tableValues.SetValue(1, email);
            tableValues.SetValue(2, passwordHash);
            command.CommandText = "[dbo].[usp_SSUser_Insert]";
            command.CommandTimeout = 15;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(tableParameter);
            connection.Open();
            using (var reader = command.ExecuteReader()) {
                do {
                    while (reader.Read()) {
                        Console.WriteLine(reader.GetInt64(0)); // TODO: something more useful, or maybe nothing...
                    }
                } while (reader.NextResult());
            }
        }
    }
    catch (SqlException e) {
        throw; // TODO: something useful with the exception
    }
