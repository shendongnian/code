            SqlConnection connLoc = new SqlConnection(YourConnectionSring);
            SqlCommand commLoc = new SqlCommand();
            SqlDataReader drLoc;
            commLoc.Connection = connLoc;
            commLoc.CommandType = CommandType.StoredProcedure;
            commLoc.CommandText = "usp_AddEmail";
            commLoc.Parameters.AddWithValue(@email, emailString);
            connLoc.Open();
            drLoc = commLoc.ExecuteReader(CommandBehavior.CloseConnection);
