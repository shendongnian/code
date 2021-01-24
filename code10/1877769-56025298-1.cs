    public User GetUserInfo(int userId) // though you might want to change the parameter to suit your needs. It's hard to tell without being able to see the schema
    {
        string select = string.Format("Select * from [tbl_accounts] where Id = {0}", userId.ToString()); // something along these lines
        SqlCommand cmd = new SqlCommand(select, conn);
    }
