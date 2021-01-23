    using (var c = new SqlConnection("..."))
    {
        var cmd1 = PrepareAndCreateCommand(c, args);
        // some code
        var cmd2 = PrepareAndCreateCommand(c, args);
        c.Open();
        cmd1.ExecuteNonQuery();
        cmd2.ExecuteNonQuery();
        c.Close();
        // more code
    }
