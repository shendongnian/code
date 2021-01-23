    using(MySqlConnection connection = new MySqlConnection(MyConString))
    {
    	connection.Open();
        using(MySqlCommand command = connection.CreateCommand())
    	{
            command.CommandText = "insert into users(addfname, addmname, addlname, addposition, addcontact, addemail, addbday, addusername, addpassword) values(@fname, @mname, @lname, @position, @contactnumber, @emailadd, @birthday, @username, @password)";
    	    command.Parameters.Add(new MySqlParameter("@fname", SqlDbType.VarChar));
            command.Parameters.Add(new MySqlParameter("@mname", SqlDbType.VarChar));
    	    command.Parameters.Add(new MySqlParameter("@lname", SqlDbType.VarChar));
            command.Parameters.Add(new MySqlParameter("@position", SqlDbType.VarChar));
            command.Parameters.Add(new MySqlParameter("@contactnumber", SqlDbType.VarChar));
            command.Parameters.Add(new MySqlParameter("@emailadd", SqlDbType.VarChar));
    	    command.Parameters.Add(new MySqlParameter("@birthday", SqlDbType.Date));
            command.Parameters.Add(new MySqlParameter("@username", SqlDbType.VarChar));
    	    command.Parameters.Add(new MySqlParameter("@password", SqlDbType.VarChar));
    	    command.Parameters["@fname"].Value = addfname.Text.ToLower();
            command.Parameters["@mname"].Value = addmname.Text.ToLower();
    	    command.Parameters["@lname"].Value = addlname.Text.ToLower();
            command.Parameters["@position"].Value = addposition.Text;
            command.Parameters["@contactnumber"].Value = addcontact.Text;
            command.Parameters["@emailadd"].Value = addemail.Text;
            command.Parameters["@birthday"].Value = addbday.Text;
            command.Parameters["@username"].Value = addusername.Text;
            command.Parameters["@password"].Value = addpassword.Text;
    
    	    //Execute command
    	    command.ExecuteNonQuery();
    	}
    }
