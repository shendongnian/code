csharp
string connectionString = GetConnectionString();
using (var connection = new MySqlConnection(connectionString))
{
    await connection.OpenAsync();
    using (var bulkCopy = new MySqlBulkCopy(connection)
    {
        // ColumnMappings isn't current supported, but they will be inferred automatically
        bulkCopy.DestinationTableName = destinationTableName;
        await bulkCopy.WriteToServerAsync(dataTable);
    }
}
