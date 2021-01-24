            var command = con.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "RoomAvailability";
            con.Open();
            SqlParameter p = new SqlParameter("@res", SqlDbType.Int);
            p.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(p);
            command.ExecuteNonQuery();
            int returnValue = (int)p.Value;
