            api.CookieContainer = new System.Net.CookieContainer();
            api.Login(user_name, password);
            Session["APIAuthenticationCookie"] = api.CookieContainer.GetCookies(new Uri(api.Url))[".ASPXAUTH"];
   
        //later request: reuse session cookie before using API
        api.CookieContainer = new CookieContainer(); 
        Cookie sessionCookie = (Cookie)Session["APIAuthenticationCookie"];
        if (sessionCookie != null)
            api.CookieContainer.Add(sessionCookie);
        api.RandomRequest();
