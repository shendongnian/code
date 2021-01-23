    SqlConnection conn = new SqlConnection(connString);
    conn.Open();
    SqlCommand cmd = new SqlCommand("insertINOUT", conn);
    cmd.CommandType = CommandType.StoredProcedure;
    
    for (int j = 0; j < weekDays.Length; j++)
    {
        **cmd.Parameters.Clear();**
        cmd.Parameters.Add(new SqlParameter("@UserName", user));
        cmd.Parameters.Add(new SqlParameter("@In", in));
        cmd.Parameters.Add(new SqlParameter("@Out", out));
        cmd.ExecuteReader();
    }
    conn.Close();
