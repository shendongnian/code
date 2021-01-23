    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
    request.CookieContainer = new CookieContainer();
    
    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    {
        foreach (Cookie cookie in response.Cookies)
        {
            Console.WriteLine(cookie.Name +  " = " +  cookie.Value);
        }
    }
