    Uri requestUri = new Uri("https://services.yesmail.com/enterprise/subscribers");            
    
    // Set the Method property of the request to POST.   
    var cache = new System.Net.CredentialCache();
    var nc = new System.Net.NetworkCredential("user/user1", "password");                 
    cache.Add(requestUri, "Basic", nc);
    var request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(requestUri);
    
    //request.PreAuthenticate = true;
    //request.KeepAlive = false;
    
    request.Method = System.Net.WebRequestMethods.Http.Post;
    request.ContentType = "application/xml;charset=ISO-8859-1";
    
    request.ContentType = "application/xml-www-form-urlencoded";       
    //request.Timeout = 300000;
    
    string EmailAddress = "test999@test1.com";
    string FirstName = "first";
    string LastName = "Last";
    
    StringBuilder Efulfill = new StringBuilder();
    
    Efulfill.Append("EmailAddress" + System.Web.HttpUtility.UrlEncode(EmailAddress));
    Efulfill.Append("FirstName" + System.Web.HttpUtility.UrlEncode(FirstName));
    Efulfill.Append("LastName" + System.Web.HttpUtility.UrlEncode(LastName));
    
    byte[] byteData = Encoding.UTF8.GetBytes(Efulfill.ToString());
    
    request.ContentType = "application/xml;charset=ISO-8859-1";
    request.ContentLength = byteData.Length;
    
    Stream postStream = request.GetRequestStream();
    postStream.Write(byteData, 0, byteData.Length);
    postStream.Close();
    
    //Get response   
    
    using (var response = (System.Net.HttpWebResponse)request.GetResponse())
    {
    	using (Stream resStream = response.GetResponseStream())
    	{
    		StreamReader reader = new StreamReader(resStream, Encoding.Default);
    		Console.WriteLine(reader.ReadToEnd());
    	}
    }
