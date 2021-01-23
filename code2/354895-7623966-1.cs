    protected void singout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        //Removes the forms-authentication ticket from the browser:
        FormsAuthentication.SignOut(); 
        FormsAuthentication.RedirectToLoginPage();
        // ...or redirect the user to any place of choice outside the protected files. 
        /*  - NOT NEEDED -...
        if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
        {
            HttpCookie myCookie = new HttpCookie(FormsAuthentication.FormsCookieName);
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(myCookie);
            FormsAuthentication.SignOut();
            Response.Redirect("Home.aspx");
        }
        */
    }
