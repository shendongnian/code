    private void btnConnect_Click(object sender, EventArgs e)
    {
        using (var con = new SqlConnection(conString))
        using (var query = new SqlCommand("INSERT INTO tbl_users (fname, mname, lname) VALUES (@fname, @mname, @lname)", con))
        {
            query.Parameters.Add("@fname", SqlDbType.VarChar, 50).Value = "Mark Dhem";
            query.Parameters.Add("@mname", SqlDbType.VarChar, 50).Value = "Subito";
            query.Parameters.Add("@lname", SqlDbType.VarChar, 50).Value = "Mansueto";
            con.Open();
            query.ExecuteNonQuery();
        }
    }
