    public ActionResult MyAction()
    {
        var container = new CookieContainer();
        if (Request.Cookies["myCookie"] != null)
        {
             // browser has passed in "myCookie".
             // use this to create the "sessionKey" cookie to send.
             var cookie = new System.Net.Cookie("sessionKey",
                 Request.Cookies["myCookie"].Value, "/", "external-site.com");
             container.Add(cookie);
        }
        HttpWebRequest request;
        HttpWebResponse response;
        // initialize the request.
        // ...
        // make sure we're using our cookie container.
        request.CookieContainer = container;
        // execute the request and get the response.
        response = request.GetResponse();
        // send a cookie, "myCookie", to the browser.
        // it will contain the value of the "sessionKey" cookie.
        Response.Cookies["myCookie"].Value = response.Cookies["sessionKey"].Value;
    }
