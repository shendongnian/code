    if (Session["UserID"] != null) 
    {
    	string theUserId = Session["UserID"].ToString();
    	Label1.Text = Convert.ToString(theUserId);
    
    	using (OdbcConnection cn = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver}; Server=localhost; Database=gymwebsite; User=root; Password=commando;")) {
    		cn.Open();
    		using (OdbcCommand cmd = new OdbcCommand("SELECT User.FirstName, User.SecondName, User.Aboutme, User.DOB, Pictures.picturepath FROM User LEFT JOIN Pictures ON User.UserID = Pictures.UserID WHERE User.UserID=@UserID", cn)) {
    
    			cmd.Parameters.AddWithValue("@UserID", theUserId);
    
    			using (OdbcDataReader reader = cmd.ExecuteReader()) {
    				while (reader.Read())
    				{
    					Name.Text = String.Format("{0} {1}", reader.GetString(0), reader.GetString(1));
    					Aboutme.Text = String.Format("{0}", reader.GetString(2));
    					Age.Text = String.Format("{0}", reader.GetString(3));
    					Image1.ImageUrl = String.Format("{0}", reader.GetString(4));
    				}
    			} // using reader
    		} // using cmd
    	} // using connection
    }
