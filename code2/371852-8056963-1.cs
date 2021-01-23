    private CookieContainer GetCookieContainer(string loginURL, string userName, string password)
    {
        var webRequest = WebRequest.Create(loginURL) as HttpWebRequest;
        var responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
        string responseData = responseReader.ReadToEnd();
        responseReader.Close();
        // Now you may need to extract some values from the login form and build the POST data with your username and password.
        // I don't know what exactly you need to POST but again a TamperData observation will help you to find out.
        string postData =String.Format("UserName={0}&Password={1}", userName, password); // I emphasize that this is just an example.
        // cookie container
        var cookies = new CookieContainer();
        // post to the login form
        webRequest = WebRequest.Create(loginURL) as HttpWebRequest;
        webRequest.Method = "POST";
        webRequest.ContentType = "application/x-www-form-urlencoded";
        webRequest.CookieContainer = cookies;
        // write the form values into the request message
        var requestWriter = new StreamWriter(webRequest.GetRequestStream());
        requestWriter.Write(postData);
        requestWriter.Close();
        webRequest.GetResponse().Close();
        return cookies;
    }
