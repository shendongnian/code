    public bool check(string username, string password)
    {
        logindal LGD = new logindal();
        DataSet ds1= LGD.logincheck(username, password);
        int noofrows = ds1.Tables["login"].Rows.Count;
        for (int i = 0; i < noofrows; i++)
        {
            if (ds1.Tables["login"].Rows[i]["username_l"].ToString().Equals(username) 
                && ds1.Tables["login"].Rows[i]["password_l"].ToString().Equals(password))
            {
                return true;
            }
        }
        return false;
    }
