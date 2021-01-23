            SqlConnection con = new SqlConnection(connectionString);
            string sqlQuery = "select  BrowserName, LoggedOnTime, BrowserVersion"
                                + " from BrowserSession inner join Users on UserId=Users.UsersId"
                                + " where UserId=21 group by BrowserName, LoggedOnTime,BrowserVersion order by BrowserName, LoggedOnTime";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "TableName");
            GridView1.DataSource = ds;
            GridView1.DataBind();
