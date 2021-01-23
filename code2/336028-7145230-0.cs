    using (var connection = new OleDbConnection(
        "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" + directoryPath 
        + "\";Extended Properties='text;HDR=Yes;FMT=Delimited(,)';"))
    using (var command = new OleDbCommand(
        "SELECT * FROM [" + fileName + "]", connection))
    {
        connection.Open();
        using (var reader = command.ExecuteReader())
            while (reader.Read())
                ...
    }
