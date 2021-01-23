    try
    {
        cmd = new OleDbCommand(query, this.DbConnection);
        OleDbDataReader reader = cmd.ExecuteReader();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.ToString());
    }
