    var connectionStringHere = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Server.MapPath("App_Data\\BookRateInitial.mdb";
    using (var conn = new OleDbConnection(connectionStringHere))
    using (var cmd = conn.CreateCommand())
    {
        cmd.CommandText = "INSERT INTO bookRated ([title], [rating],  [review], [frnISBN], [frnUserName]) VALUES(?, ?, ?, ?, ?)";
        cmd.Parameters.Add(new OleDbParameter("?", OleDbType.VarChar, 100) { Value = title});
        cmd.Parameters.Add(new OleDbParameter("?", OleDbType.Integer) { Value = rating });
        cmd.Parameters.Add(new OleDbParameter("?", OleDbType.VarChar, 2000) { Value = review });
        cmd.Parameters.Add(new OleDbParameter("?", OleDbType.VarChar, 60) { Value = ISBN });
        cmd.Parameters.Add(new OleDbParameter("?", OleDbType.VarChar, 256) { Value = userName });
        conn.Open();
        var numberOfRowsInserted = cmd.ExecuteNonQuery();
    }
	
