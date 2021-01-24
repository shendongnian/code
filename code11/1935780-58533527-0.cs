cmd.CommandText = "INSERT INTO tablename(column1,column2,column3) VALUES(@column1,@column2,@column3)
There is some discussion about risks of `AddWithValue` so you may want to opt for the Add(...).Value approach.
command.Parameters.Add("@column1", SqlDbType.Int).Value = x;
command.Parameters.Add("@column2", SqlDbType.Int).Value = y;
command.Parameters.Add("@column3", SqlDbType.Int).Value = z;
----
You should be using the `using` statement.
var commandText = "INSERT INTO tablename(column1,column2,column3) VALUES(@column1,@column2,@column3)
using (SqlConnection connection = new SqlConnection(connectionString))
{
    SqlCommand command = new SqlCommand(commandText, connection);
    command.Parameters.Add("@column1", SqlDbType.Int).Value = x;
    command.Parameters.Add("@column2", SqlDbType.Int).Value = y;
    command.Parameters.Add("@column3", SqlDbType.Int).Value = z;
    try
    {
        connection.Open();
        Int32 rowsAffected = command.ExecuteNonQuery();
        Console.WriteLine("RowsAffected: {0}", rowsAffected);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
