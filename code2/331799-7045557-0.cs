    SqlCommand cmd = new SqlCommand("SELECT * FROM Dongles WHERE SerialNumber = @SerialNo", server.SQLConnection);
    cmd.Parameters.Add("@SerialNo", SqlDbType.VarChar, 50).Value = m_dongle.SerialNumber.Trim();
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    SqlCommandBuilder cb = new SqlCommandBuilder(da);
    DataTable dt = new DataTable();
    da.Fill(dt);
    if (dt.Rows.Count > 0)
    {
        .......
    }
