    static List<Thing> GetDetailsForItems(List<string> items)
    {
        DateTime start = DateTime.UtcNow;
        var things = new List<Thing>();
        var spname = "SP_GET_THING_DETAILS";
        var outRefCursorName1 = "p_ref_cursor1";
        var outRefCursorName2 = "p_ref_cursor2";
        try
        {
            int count = 0;
            using (var conn = new OracleConnection(CONN_STR))
            try
            {
                conn.Open();
                // Create params
                var pInput1 = new OracleParameter("p_input1", OracleDbType.Varchar2, ParameterDirection.Input);
                pInput1.Value = "";
                // Input 2 can be blank
                var pInput2 = new OracleParameter("p_input2", OracleDbType.Varchar2, ParameterDirection.Input);
                pInput2.Value = "";
                var outRefCursor1 = new OracleParameter(outRefCursorName1, OracleDbType.RefCursor, ParameterDirection.Output);
                var outRefCursor2 = new OracleParameter(outRefCursorName2, OracleDbType.RefCursor, ParameterDirection.Output);
                using (var cmd = conn.CreateCommand())
                {
                    cmd.Parameters.Add(pInput1);
                    cmd.Parameters.Add(pInput2);
                    cmd.Parameters.Add(outRefCursor1);
                    cmd.Parameters.Add(outRefCursor2);
                    cmd.CommandText = spname;
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (string value in items)
                    {
                        count++;
                        cmd.Parameters[pInput1.ParameterName].Value = value;
                        var execVal = cmd.ExecuteNonQuery();
                        using (var refCursor = (Types.OracleRefCursor)
                                               cmd.Parameters[outRefCursorName1].Value)
                        {
                            using (var reader = refCursor.GetDataReader())
                            {
                                while (reader.Read())
                                {
                                    // read columns
                                    things.Add(reader["COLUMN_A"].ToString());
                                }
                            } // close reader
                        } // close cursor
                    } // end foreach
                } // close command
            } // close connection
            finally
            {
                pInput1.Dispose();
                pInput2.Dispose();
                outRefCursorName1.Dispose();
                outRefCursorName2.Dispose();
            }
        }
        int seconds = (DateTime.UtcNow - start).Seconds;
        Console.WriteLine("Finished in {0} seconds", seconds);
        return things;
    }
