    Byte[] hashedBytes;
    string Password = txtPassword.Text;
    MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
    UTF8Encoding encoder = new UTF8Encoding();
    hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(Password));
    
    Response.Write(string.Format("Hashed Password (Given): {0}<br />", hashedBytes.ToString()));
    string UserName = txtUserName.Text;
    SqlConnection con = new SqlConnection("Data Source=Shihab-PC;Initial Catalog=test;User ID=sh;password=admin");
    con.Open();
    
    SqlCommand cmdd = new SqlCommand(string.Format("select * from Users where UserName='{0}'", UserName),con);
    SqlDataReader dr = cmdd.ExecuteReader();
    //should be only one row..
    while (dr.Read())
    {
        Response.Write(string.Format("Hashed Password (DB): {0}", dr["password"].ToString()));
    }
    dr.Close();
    con.Close(); 
