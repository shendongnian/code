csharp
// set up command
using (var command = new MySqlCommand("sproc_name", connection))
{
    command.CommandType = CommandType.StoredProcedure;
    // register cancellation to occur in five minutes
    using (var cts = new CancellationTokenSource(TimeSpan.FromMinutes(5)))
    using (cts.Token.Register(() => command.Cancel())
    {
        // execute the stored procedure as normal
        using (var reader = command.ExecuteReader())
        {
            // use reader, or just call command.ExecuteNonQuery instead if that's what you need
        }
    }
}
