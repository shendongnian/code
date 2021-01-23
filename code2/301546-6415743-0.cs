    //Assuming you already have a connection somewhere that is opened.
    var sql = "INSERT INTO mytable (name, theblob) VALUES (?, ?);";
    using (var command = new IfxCommand(sql, connection))
    {
        command.Parameters.Add(new IfxParameter()).Value = "foo";
        command.Parameters.Add(new IfxParameter()).Value = ifxBlob;
    }
