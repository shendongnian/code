using (var connection=new SqlConnection(connectionString))
{
    var command = new SqlCommand(someQuery,connection);
    connection.Open();
    using(var reader = command.ExecuteReader())
    {
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                var csv=reader.GetString(0);
                var parts=csv.Split(",");
                //Do something with the second part
                Console.WriteLine(parts[1]);
            }
        }
        else
        {
            Console.WriteLine("No rows found.");
        }
    }
}
The `using` blocks ensure the connection and reader are closed even if there's an exception. Without them, they may remain open for a long time, leading to blocking or even deadlocks.
With Dapper, things are even easier. Assuming the query returns a single field :
using (var connection=new SqlConnection(connectionString))
{
    //Executes the query and returns the result either as raw values 
    //or strongly-typed objects
    var items=connection.Query<string>(someQuery,connection);
    foreach(var csv in items)
    {
        var parts=csv.Split(",");
        //Do something with the second part
        Console.WriteLine(parts[1]);
    }
}
Using LINQ, this can be simplified further:
using (var connection=new SqlConnection(connectionString))
{
    //Combine querying and splitting
    var items=connection.Query<string>(someQuery,connection)
                        .Select(csv=>csv.Split(",")[1]);
    foreach(var vallue in items)
    {
        //Do something with that value
        Console.WriteLine(value);
    }
}
Or, as a function that returns the values directly :
IEnumerable<string> SecondValues(string connectionString)
{
    using (var connection=new SqlConnection(connectionString))
    {
        //Combine querying and splitting
        var items=connection.Query<string>(someQuery,connection)
                            .Select(csv=>csv.Split(",")[1]);
        return items;
    }
}
