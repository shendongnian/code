    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand cmd = connection.CreateCommand())
    {
        cmd.CommandText = commandName;
        cmd.CommandType = CommandType.StoredProcedure;
        ...
        cmd.Parameters.Add("@source", SqlDbType.VarChar, 50).Value = flightsession.Sscource;
        cmd.Parameters.Add("@destination", SqlDbType.VarChar, 50).Value = flightsession.Sdestination;
        cmd.Parameters.Add("@fn", SqlDbType.VarChar, 40).Value = flightsession.Sflightname;
        cmd.Parameters.Add("@fc", SqlDbType.VarChar, 50).Value = flightsession.Total;
        cmd.Parameters.Add("@fty", SqlDbType.VarChar, 50).Value = flightsession.Stype;
        cmd.Parameters.Add("@fcl", SqlDbType.VarChar, 50).Value = flightsession.Sflightclass;
        connection.Open(); // open just now!
        cmd.ExecuteNonQuery();
    } // using block call Dispose() for each object locker to guarantee close of the connection
