    public int StudentId()
    {
        string sql = "SELECT s_id FROM student WHERE name = @name";
        using (var con = new SqlConnection(connectionStr))
        {
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@name", DbType.VarChar, 256).Value = Request.QueryString["name"];
                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
    }
