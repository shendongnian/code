    var dependency = new SqlDependency();
    var SqlCommand cmd = new SqlCommand(sqlStatement);
    dependency.AddCommandDependency(cmd);
    dependency.OnChange += (o, e) =>
    {
        Console.WriteLine("Notification called !");
    };
    // Executing the command will submit the query notification request
    using (SqlDataReader rdr = cmd.ExecuteReader ()) {
       while (rdr.Reader ()) {
          ...
       }
    }
    Console.Reade ();
