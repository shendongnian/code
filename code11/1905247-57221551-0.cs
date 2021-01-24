using (var connection = mydbcontext.Database.Connection)
{
    connection.Open();
    var command = connection.CreateCommand();
    command.CommandText = string.Format(@"EXEC prDailyRouteReport 
                                 {0}",refId);
    using (var reader = command.ExecuteReader())
    {
       //reading data and fetch next result
    }
    command = connection.CreateCommand();
    command.CommandText = string.Format(@"EXEC prDailyRouteReport2 
                                 {0}",refId);
    using (var reader = command.ExecuteReader())
    {
       //reading data and fetch next result
    }
    connection.Close()
}
