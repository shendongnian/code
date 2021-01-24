    partial void OnContextCreated()
    {
        System.Data.Common.DbCommand command = this.Connection.CreateCommand();
        command.CommandText = "set collation_connection = utf8_slovenian_ci;";
        command.CommandType = System.Data.CommandType.Text;
        this.Connection.Open();
        command.ExecuteNonQuery();
    }
