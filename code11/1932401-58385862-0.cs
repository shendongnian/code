    using (var connection = DataBase.GetConnection())
    using (var command = connection.CreateCommand())
    {
        command.CommandText = "DELETE FROM People WHERE ID = @ID";
        var parameter = new SqlParameter
        {
            ParameterName = "@ID",
            SqlDbType = SqlDbType.Int,
            Value = Id
        };
        command.Parameters.Add(parameter);
        connection.Open();
        command.ExecuteNonQuery();
    }
