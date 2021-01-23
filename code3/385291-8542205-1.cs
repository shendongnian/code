     string getUrl = "https://www.facebook.com/login.php?login_attempt=1";
     string postData = String.Format("email={0}&pass={1}", "value1", "value2");
     HttpWebRequest getRequest = (HttpWebRequest)WebRequest.Create(getUrl);
     getRequest.CookieContainer = new CookieContainer();
     getRequest.CookieContainer.Add(cookies); //recover cookies First request
     getRequest.Method = WebRequestMethods.Http.Post;
     getRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
     getRequest.AllowWriteStreamBuffering = true;
     getRequest.ProtocolVersion = HttpVersion.Version11;
     getRequest.AllowAutoRedirect = true;
     getRequest.ContentType = "application/x-www-form-urlencoded";
     byte[] byteArray = Encoding.ASCII.GetBytes(postData);
     getRequest.ContentLength = byteArray.Length;   
     Stream newStream = getRequest.GetRequestStream(); //open connection
     newStream.Write(byteArray, 0, byteArray.Length); // Send the data.
     newStream.Close();
     HttpWebResponse getResponse = (HttpWebResponse)getRequest.GetResponse();
     using (StreamReader sr = new StreamReader(getResponse.GetResponseStream()))
     {
       string sourceCode = sr.ReadToEnd();               
     } 
