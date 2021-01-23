    using System.Data;
    using System.Data.SqlClient
    public DataTable GetUserDetails(int userID)
    {
        DataTable dTable = new DataTable();
    
        using (SqlConnection con = new SqlConnection(<your connection string>))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(new SqlParameter("@userid", userID);
            cmd.Text = "SELECT DISTINCT u.userid, u.username, u.img1, u.birthday, u.genid, u.city, u.state, u.country, u.title FROM UserInfo u JOIN Network n ON u.userid = n.userid WHERE n.userid = ?";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);        
        
            da.Fill(dTable);
        }
        return dTable;
    }
