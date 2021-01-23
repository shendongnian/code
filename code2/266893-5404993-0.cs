    private void PopulateWallPosts(string userId)
    {
    	using (OdbcConnection cn = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver}; Server=localhost; Database=gymwebsite2; User=user_name; Password=password_here;"))
            {
    		cn.Open();
    		using (OdbcCommand cmd = new OdbcCommand("SELECT Wallpostings FROM WallPosting WHERE UserID=" + userId) + " ORDER BY idWallPosting DESC", cn))
    		{
    			using (OdbcDataReader reader = cmd.ExecuteReader())
    			{
    				var divHtml = new System.Text.StringBuilder();
    				while (reader.Read())
    				{
    					divHtml.Append("<div id=test>");
    					divHtml.Append(String.Format("{0}", reader.GetString(0)));
    					divHtml.Append("</div>");
    				}
    				test1.InnerHtml = divHtml.ToString();
    			}
    		}
    	}
    }
