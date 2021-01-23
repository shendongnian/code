    //1. Create a dictionary to store cookie collection
    
        public static Dictionary<string, Cookie> CookieCollection { get; set; }
    
    //2. Store cookie in that collection
      
    
    foreach (Cookie clientcookie in response.Cookies)
         {
                        if (!CookieCollection.ContainsKey("AuthCookieName"))
                            CookieCollection .Add(userName, clientcookie);
                        else
                            CookieCollection ["userName"] = clientcookie;
        }
    
    //3. If remember me is clicked then send the same while creating request
    
        request.CookieContainer.Add(request.RequestUri, 
    new Cookie("AuthCookieName", CookieCollection ["userName"]));
    
   
