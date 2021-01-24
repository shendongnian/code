using (var connection = new SqlConnection()) {
    connection.ConnectionString = YourConnectingString;
    using (var command = new SqlCommand(procedure, connection)) {
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("@codigo", SqlDbType.Int).Value = int.Parse(codigof.Text);
        connection.Open();
        command.ExecuteNonQuery();
        using (var da = new SqlDataAdapter(command)) {
            da.Fill(_dt);
        }
    }
}
Like I said in the comment section above, I am not familiar with PostgreSQL, so I can't really say if your stored procedure is correct...
