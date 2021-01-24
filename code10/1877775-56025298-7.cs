    public User GetUserInfo(int userId) // though you might want to change the parameter to suit your needs. It's hard to tell without being able to see the schema for the user table
    {
        User user = new User();
        string select = string.Format("Select * from [tbl_accounts] where Id = {0}", userId.ToString()); // something along these lines
        SqlCommand cmd = new SqlCommand(select, conn);
        if(dr.Read())
        {   
            user.AccountId = dr["accountID"].ToString();
            user.UserName = dr["username"].ToString();
            user.Name = dr["name"].ToString();
            user.Strand = dr["strand"].ToString();
            user.Section = dr["section"].ToString();
        }
        return user;
    }
    public void SetValues(User user) 
    {
        materialLabel6.Text = user.AccountId;
        materialLabel7.Text = user.UserName;
        materialLabel8.Text = user.Name;
        materialLabel9.Text = user.Strand;
        materialLabel10.Text = user.Section;
    }
    public class User 
    {
        string AccountId { get; set; }
        string UserName { get; set; }
        string Name { get; set; }
        string Strand { get; set; }
        string Section { get; set; }
    }
