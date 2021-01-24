using (var ctx = new DataContext())
{
    using (var command = ctx.Database.GetDbConnection().CreateCommand())
    {
        command.CommandText = "SELECT name from sqlite_master WHERE type='table'";
        ctx.Database.OpenConnection();
        using (var result = command.ExecuteReader())
        {
            while (result.Read())
            {
                Console.WriteLine(result.GetString(0));
            }
        }
    }
}
