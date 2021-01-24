public void deleteUser(int userId) 
{
    var sql = "DELETE User WHERE User.UserID = @id;";
    if (_cmds.TryGetValue("deleteUser", out SqlCommand cmd)) 
    {
        lock(cmd) 
        { 
            cmd.Parameters[0].Value = userId;
            cmd.ExecuteNonQuery();
        }
    }
}
For the non-query commands you could write a function like this in your class which will eliminate the repetitive code to open a connection, create a command, etc:
    private void ExecuteNonQuery(string sql, Action<SqlCommand> addParameters = null)
    {
        using (var connection = new SqlConnection(_connectionString))
        using (var command = new SqlCommand(sql))
        {
            addParameters?.Invoke(command);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
Save the following snippet of code. You might even just be able to keep it in the clipboard most of the time. Paste it into each one of your non-query methods right beneath the SQL:
    ExecuteNonQuery(sql, command =>
    {
    });
After you paste it, move the line or lines that add parameters into the body of the `cmd` argument (which is named `cmd` so that you can move the lines without changing the variable name) and then delete the existing code that executed the query previously.
    ExecuteNonQuery(sql, cmd =>
    {
        cmd.Parameters[0].Value = userId;
    });
Now your function looks like this:
public void deleteUser(int userId) 
{
    var sql = "DELETE User WHERE User.UserID = @id;";
    ExecuteNonQuery(sql, cmd =>
    {
        cmd.Parameters[0].Value = userId;
    });
}
I'm not saying that's fun, but it will make the process of editing those functions more efficient since you're typing less and just moving things around in exactly the same way over and over.
The ones that actually return data are less fun, but still manageable.
First, take pretty much the same boilerplate code. This could likely be improved because it's still a little repetitive, but at least it's more self-contained:
    using (var connection = new SqlConnection(_connectionString))
    using (var cmd = new SqlCommand(sql)) // again, named "cmd" on purpose
    {
        
        connection.Open();        
    }
Starting with this:
`
public int isConnected(int userId, out int name) 
{
    var sql = "SELECT * FROM User WHERE User.UserID = @id;";'
    bool result = false;
    amount = 0;
    if (_cmds.TryGetValue("userInfo", out SqlCommand cmd)) 
    {
        lock (cmd) 
        {
            cmd.Parameters[0].Value = userId;
            using (SqlDataReader reader = new cmd.ExecuteReader()) 
            {
                 if (reader.HasRows)
                     while (reader.Read()) 
                     {
                         amount = (int)Math.Round(reader.GetDecimal(0));
                         result = reader.GetInt32(1);
                     }
            }
        }
    }
}
`
Paste your boilerplate into the method:
`
public int isConnected(int userId, out int name) 
{
    var sql = "SELECT * FROM User WHERE User.UserID = @id;";'
    bool result = false;
    amount = 0;
    using (var connection = new SqlConnection(_connectionString))
    using (var cmd = new SqlCommand(sql)) // again, named "cmd" on purpose
    {
        
        connection.Open();        
    }
    if (_cmds.TryGetValue("userInfo", out SqlCommand cmd)) 
    {
        lock (cmd) 
        {
            cmd.Parameters[0].Value = userId;
            using (SqlDataReader reader = new cmd.ExecuteReader()) 
            {
                 if (reader.HasRows)
                     while (reader.Read()) 
                     {
                         amount = (int)Math.Round(reader.GetDecimal(0));
                         result = reader.GetInt32(1);
                         // was this a typo? The code in the question doesn't
                         // return anything or set the "out" variable. But
                         // if that's in the method then that will be part of
                         // what gets copied.
                     }
            }
        }
    }
}
`
Then, just like before, move the part where you add your parameters above `connection.Open();` and move the part where you use the command just beneath `connection.Open();` and delete what's left. The result is this:
`
public int isConnected(int userId, out int name) 
{
    var sql = "SELECT * FROM User WHERE User.UserID = @id;";'
    bool result = false;
    amount = 0;
    using (var connection = new SqlConnection(_connectionString))
    using (var cmd = new SqlCommand(sql)) // again, named "cmd" on purpose
    {
        cmd.Parameters[0].Value = userId;
        connection.Open();        
        using (SqlDataReader reader = new cmd.ExecuteReader()) 
        {
             if (reader.HasRows)
                 while (reader.Read()) 
                 {
                     amount = (int)Math.Round(reader.GetDecimal(0));
                     result = reader.GetInt32(1);
                 }
        }
    }
}
`
You can probably get into a groove and do these in a minute or two each, which means that it will only take a few hours.
Once all of this is done you can delete your massive dictionary function. Now the class depends on an injected connection string and opens and closes connections normally instead of storing a connection and using it over and over.
You can also break it up. One way is to move the connection string and the helper function into a base class (or just duplicate the helper function - it's really small) and you can move any of the query functions into a smaller class because each function is self-contained.
