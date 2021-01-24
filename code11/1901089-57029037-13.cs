    var connectionString = "Data Source=.;Initial Catalog=Koholint;Trusted_Connection=True;";
    var userName = register_username.Text;
    var email = register_mail.Text;
    var passwordHash = register_password.HashBytes;
    try {
        var tableMetadata = new[] {
            new SqlMetaData("UserName", SqlDbType.NVarChar, 255),
            new SqlMetaData("Email", SqlDbType.NVarChar, 255),
            new SqlMetaData("PasswordHash", SqlDbType.VarBinary, 64),
        };
        var tableValues = new SqlDataRecord(tableMetadata);
        tableValues.SetValue(0, userName);
        tableValues.SetValue(1, email);
        tableValues.SetValue(2, passwordHash);
        using (var connection = new SqlConnection(connectionString))
        using (var command = connection.CreateCommand()) {
            command.CommandText = "[dbo].[usp_SSUser_Insert]";
            command.CommandTimeout = 15;
            command.CommandType = CommandType.StoredProcedure;
            var tableParameter = new SqlParameter("users", SqlDbType.Structured);
            tableParameter.TypeName = "[dbo].[ISSUser]";
            tableParameter.Value = new[] { tableValues };
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
        register_error.Visible = true;
        if (e.Number == 2627) {
            // special handling for primary key violation
        }
        else {
            throw; // rethrow everything else
        }
    }
    register_username.Text = "";
    register_password.Text = "";
    register_mail.Text = "";
    Response.Redirect("Login.aspx");
