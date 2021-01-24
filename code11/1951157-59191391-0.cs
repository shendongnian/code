    public string GetUserPage(string userId)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        SqlCommand cmd = new SqlCommand("SELECT * FROM Permission Where UserId = @userId", conn);
        cmd.Parameters.AddWithValue("@userId", userId);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataTable dt = new DataTable();
        da.Fill(dt);
        foreach (DataRow row in dt.Rows)
        {
            if (row["Page"] != null)
            {
                return row["Page"].ToString();
            }
        }
        return null;
    }
