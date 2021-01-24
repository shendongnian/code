    public User GetUserInfo(int userId) // though you might want to change the parameter to suit your needs. It's hard to tell without being able to see the schema
    {
        string select = string.Format("Select * from [tbl_accounts] where Id = {0}", userId.ToString()); // something along these lines
        SqlCommand cmd = new SqlCommand(select, conn);
        if(dr.Read())
        {
            // ideally you'd want to separate the sql code from the UI code if I'm reading this right, best practice is to have it return an object for use outside of the function
            return new User() 
             {
                AccountId = dr["accountID"].ToString(),
                UserName = dr["username"].ToString(),
                Name = dr["name"].ToString(),
                Strand = dr["strand"].ToString(),
                Section = dr["section"].ToString()
             };
            // but if you want to set the fields the way you were doing, you can go with what you have
            /*
            materialLabel6.Text = dr["accountID"].ToString();
            materialLabel7.Text = dr["username"].ToString();
            materialLabel8.Text = dr["name"].ToString();
            materialLabel9.Text = dr["strand"].ToString();
            materialLabel10.Text = dr["section"].ToString();
            */
        }
