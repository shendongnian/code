    protected void lbtnSignIn_Click(object sender, EventArgs e)
    {
     .......Login credential checking code......
     .......If the use verified, then add the roles to FormsAuthenticationTicket 
     .......I am assuming in the below code, you are getting list of roles from DB in DataTable
     String roles = String.Empty;
     if (dtblUsersRoles.Rows.Count > 0)
        {
         for (int count = 0; count < dtblUsersRoles.Rows.Count; count++)
         {
          //build list of roles in comma seperate
          roles = roles + "," + dtblUsersRoles.Rows[count]["RoleName"].ToString();
         }
        }
    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, txtUserID.Text, 
    DateTime.Now, DateTime.Now.AddMinutes(30), false, roles.Substring(1, roles.Length - 1), FormsAuthentication.FormsCookiePath);
    string hashCookies = FormsAuthentication.Encrypt(ticket);
    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashCookies);
    Response.Cookies.Add(cookie);
    }
