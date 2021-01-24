    public enum FieldType
    {
    	EmailAddress,
    	UserName
    }
    
    protected void register_Click(object sender, EventArgs e)
    {
    	if(!checkfield(FieldType.EmailAddress) && !checkfield(FieldType.UserName))
    	{
    		// Both email address and username are avialable
    		// do some stuff
    		return;
    	}
    	if(checkfield(FieldType.EmailAddress)
    	{
    		// Email address is taken
    		// do some stuff
    		return;
    	}
    	if(checkfield(FieldType.UserName)
    	{
    		// Username is taken
    		// do some stuff
    		return;
    	}
    }
    
    private bool checkfield(FieldType field)
    {
    	string sql = string.Empty;
    	switch(field)
    	{
    		case FieldType.EmailAddress:
    		sql = "SELECT COUNT(*) FROM Users WHERE emailId = @p;";
    		break;
    
    		case FieldType.UserName:
    		sql = "SELECT COUNT(*) FROM Users WHERE username = @p;";
    		break;
    	}
    	SqlCommand cmd = con.CreateCommand();
    	cmd.CommandType = CommandType.Text;
    	cmd.CommandText = sql;
    	switch(field)
    	{
    		case FieldType.EmailAddress:
    		cmd.Parameters.AddWithValue("@p", email.Text);
    		break;
    
    		case FieldType.UserName:
    		cmd.Parameters.AddWithValue("@p", uname.Text);
    		break;
    	}
    	var rows = cmd.ExecuteScalar();
    	if(int.Parse(rows.ToString()) > 0)
    	{
    		return false;
    	}
    	return true;
    }
