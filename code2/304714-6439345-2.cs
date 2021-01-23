    public User GetUserByCredentials(string username, string password)
    {
    	IQuery query = Session.GetNamedQuery("GetUserByCredentials");
    	query.SetParameter("Username", username);
    	query.SetParameter("Password", password);
    
    	return query.UniqueResult<User>();
    }
