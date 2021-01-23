    protected void singout_Click(object sender, EventArgs e) 
        { 
            Session.Abandon(); 
            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null) 
            { 
                HttpCookie myCookie = new HttpCookie(FormsAuthentication.FormsCookieName); 
                myCookie.Expires = DateTime.Now.AddDays(-1d); 
                Response.Cookies.Add(myCookie); 
                FormsAuthentication.SignOut(); 
            }
            Response.Redirect("Home.aspx"); 
        } 
