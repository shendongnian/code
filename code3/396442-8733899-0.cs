    public DataTable GetMembers(int MEMBERSHIPGEN)
    {
        DataTable table = new DataTable();
        SqlConnection con = new SqlConnection(connectionString);
    
        using (SqlCommand cmd = new SqlCommand("usp_getmemberdetail", con))
        {
            using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
            {
                SqlParameter prm = new SqlParameter("@MEMBERSHIPGEN", SqlDbType.Int);
                prm.Value = MEMBERSHIPGEN;
                cmd.Parameters.Add(prm);
                ad.Fill(table);
                return table;
            }
