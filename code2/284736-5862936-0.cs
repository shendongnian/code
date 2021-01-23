    HttpCookie cookie = new HttpCookie("Email"); 
            cookie.Value = txtEmail.Text;
            DateTime dtNow = DateTime.Now;
            cookie.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(cookie);
