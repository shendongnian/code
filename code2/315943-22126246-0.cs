    System.Collections.Specialized.NameValueCollection cookiecoll = new System.Collections.Specialized.NameValueCollection();
             
                cookiecoll.Add(bizID.ToString(), rate.ToString());
            
            HttpCookie cookielist = new HttpCookie("MyListOfCookies");
            cookielist.Values.Add(cookiecoll);
            HttpContext.Current.Response.Cookies.Add(cookielist);
