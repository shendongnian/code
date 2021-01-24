    // I'll assume that a connection is already open
    using (var command = new SqlCommand("SQL Command goes here")
    {
        var dependency = new SqlDependency(command);
        dependency.OnChange += (object, SqlNotificationEventArgs e) => 
        {
            // Handle OnChange here
            Console.WriteLine(e.Info);
        }
    
        // You can do all the things with the SQL Command here as you normally could
        // for example execute it if it's a SELECT and read data
    }
