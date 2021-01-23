    while (rd.Read())
        {
            string stateincharge = rd["stateincharge"].ToString();
            string email = rd["email"].ToString();
            cmd.Dispose();
            cmd = con.CreateCommand();
            cmd.CommandText = "str_procedure";
            cmd.Parameters.AddWithValue("@stateincharge", stateincharge);
            cmd.CommandType = CommandType.StoredProcedure;
            ad.SelectCommand = cmd;
            ad.Fill(ds);
            count = ds.Tables[0].Rows.Count;
            DataTable dt = new DataTable();
    }
    rd.Close();
