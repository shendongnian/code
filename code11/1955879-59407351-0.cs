public async Task<int> ExecuteNonQueryAsync(string connectionString, string query, 
       CancellationToken cancellationToken)
{
    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        using (MySqlCommand command = new MySqlCommand(query,connection))
        {
            await connection.OpenAsync();
            command.CommandTimeout = 0;
            var affectedRowsCount = await command.ExecuteNonQuery(cancellationToken);
         }
    }
 
    return affectedRowsCount;
}
