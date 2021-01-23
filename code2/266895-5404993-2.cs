    protected void Button1_Click(object sender, EventArgs e)
    {
    	string theUserId = Session["UserID"].ToString();
    	using (OdbcConnection cn = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver}; Server=localhost; Database=gymwebsite2; User=user_name; Password=password_here;"))
    	{
    		cn.Open();
    		using (OdbcCommand cmd = new OdbcCommand("INSERT INTO WallPosting (UserID, Wallpostings) VALUES (" + theUserId + ", '" + TextBox1.Text + "')", cn))
    		{
    			cmd.ExecuteNonQuery();
    		}
    	}
    	PopulateWallPosts(theUserId);
    }
