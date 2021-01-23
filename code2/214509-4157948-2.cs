    SqlConnection con = new SqlConnection("Data Source=Shihab-PC;Initial Catalog=test;User ID=sh;password=admin");
    con.Open();
    string UserName = txtUserName.Text;
    string Password = txtPassword.Text;
    
    //hash password
    MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
    Byte[] hashedBytes;
    UTF8Encoding encoder = new UTF8Encoding();
    hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(Password));
    Password = hashedBytes;
    
    bool isMatch = false;
    SqlCommand cmdd = new SqlCommand(string.Format("select * from Users where UserName='{0}'", UserName),con);
    SqlDataReader dr = cmdd.ExecuteReader();
    while (dr.Read())
    {
        if (dr["password"].ToString()==Password)  
        {
            isMatch = true;
        }
    }
    dr.Close();
    con.Close(); 
    if (isMatch)
    {
        Response.Write("correct");
    }
    else
    {
        Response.Write("Incorrect username or password!");
    }
