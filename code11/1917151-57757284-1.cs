    public string DbCon = 
     ConfigurationManager.ConnectionStrings["DbConnection"].ToString();
    var Query=@"INSERT INTO [dbo].[registration]([username[fullname],[Password]) VALUES('" + username.Text+"', '"+fullname.Text+"', '"+password.Text+"')"
    using (con = new SqlConnection(DbCon))
            {
                con.Open();
                SqlCommand com = new SqlCommand(Query, con);
                com.ExecuteNonQuery();
                con.Close();
            }
