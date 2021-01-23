    cmd = new SqlCommand("GetIslemIdleri", sqlConn);
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.Add(new SqlParameter("@CARIID", 110));
    using (var reader = cmd.ExecuteReader()) //error occurs here
    {
        while (reader.Read())
        {
            islemidleri.Add(reader.GetInt32(0));
        }
    }
