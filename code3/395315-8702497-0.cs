    public int GetStudentId()
    {
        var sql = string.Format("SELECT s_id FROM student where name = '{0}'", Request.QueryString);
        using (var con = new SqlConnection(connectionStr))
        using (var cmd = new SqlCommand(sql, con))
        {
            con.Open();
            var dr = cmd.ExecuteReader();
            return dr.Read() ? return dr.GetInt32(0) : -1;
        }
    }
