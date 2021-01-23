    // Creating WebRequest  
    var req = (HttpWebRequest)WebRequest.Create(ServerPath + controllerName + "/" + actionName);  
    var coockieContainer = new CookieContainer();
    
    // AuthCookie is static variable defined. Initially it will be null. But when server  
    // respond with auth cookie then we have to store it and add to container for further  
    // communication.  
    
    if (AuthCookie != null)  
    {  
        coockieContainer.Add(AuthCookie);  
    }  
    req.CookieContainer = coockieContainer;  
    
    req.Headers.Add("SOAPAction", "\"\"");  
    req.ContentType = "application/json; charset=utf-8";  
    req.ContentLength = bytes.Length;  
    req.Accept = "application/json, text/javascript, */*";  
    req.Method = "POST";  
    var stm = req.GetRequestStream();  
    stm.Write(bytes, 0, bytes.Length);  
    stm.Close();  
    var resp = req.GetResponse();  
    
    // If server respond with auth cookie then we have to store it.  
    // Here I have used ".ASPXAUTH" name. You can have your own defined name
    if (AuthCookie == null)  
    {  
        AuthCookie = ((HttpWebResponse)resp).Cookies.Cast<Cookie>().Where(cook => 
    cook.Name.Equals(".ASPXAUTH")).FirstOrDefault();  
        // Print the properties of each cookie.
        Console.WriteLine("Cookie:");
        Console.WriteLine("{0} = {1}", AuthCookie.Name, AuthCookie.Value);  
        Console.WriteLine("Domain: {0}", AuthCookie.Domain);  
        Console.WriteLine("Path: {0}", AuthCookie.Path);  
        Console.WriteLine("Port: {0}", AuthCookie.Port);  
        Console.WriteLine("Secure: {0}", AuthCookie.Secure);  
        Console.WriteLine("When issued: {0}", AuthCookie.TimeStamp);  
        Console.WriteLine("Expires: {0} (expired? {1})", AuthCookie.Expires, AuthCookie.Expired);  
        Console.WriteLine("Don't save: {0}", AuthCookie.Discard);  
        Console.WriteLine("Comment: {0}", AuthCookie.Comment);  
        Console.WriteLine("Uri for comments: {0}", AuthCookie.CommentUri);  
        Console.WriteLine("Version: RFC {0}", AuthCookie.Version == 1 ? "2109" : "2965");  
    
        // Show the string representation of the cookie.
        Console.WriteLine("String: {0}", AuthCookie.ToString());
    
    }  
    
    var stmr = new StreamReader(resp.GetResponseStream());  
    
    var json = stmr.ReadToEnd();  
