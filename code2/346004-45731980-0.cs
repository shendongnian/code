    SqlConnection conn = new SqlConnection(connString);
    conn.Open();
    SqlCommand cmd = new SqlCommand("insertINOUT", conn);
    
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@UserName", user));
        for (int j = 0; j < weekDays.Length; j++)
        {
       
           
            cmd.Parameters.Add(new SqlParameter("@In"+j, in));
            cmd.Parameters.Add(new SqlParameter("@Out"+j, out));
            cmd.ExecuteReader();
        }
        conn.Close();
