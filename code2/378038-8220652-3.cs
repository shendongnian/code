    using (var conn = new OracleConnection("your connection string")) {
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "TEST_INSERT";
        var param = cmd.Parameters.Add("ID", OracleDbType.Int32, System.Data.ParameterDirection.Input);
        int[] arr = { 1, 2, 3, 4, 5, 6 };
        param.Value = arr;
        cmd.ArrayBindCount = arr.Length;
        cmd.ExecuteNonQuery();
    }
