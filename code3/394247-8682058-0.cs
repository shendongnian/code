     string key = "diigo api key";
     string username = "username";
     string pass = "password";
     string url = "https://secure.diigo.com/api/v2/";     
     string requestUrl = url + "bookmarks?key=" + key + "&user=" + username + "&count=5";
     HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(requestUrl);
     string usernamePassword = username + ":" + pass;
     myReq.Timeout = 20000;
     myReq.UserAgent = "Sample VS2010";
     //Use the CredentialCache so we can attach the authentication to the request
     CredentialCache mycache = new CredentialCache();
     //this perform Basic auth
     mycache.Add(new Uri(requestUrl), "Basic", new NetworkCredential(username, pass));
     myReq.Credentials = mycache;
     myReq.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(usernamePassword)));
      //Send and receive the response
      WebResponse wr = myReq.GetResponse();
      Stream receiveStream = wr.GetResponseStream();
      StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
      string content = reader.ReadToEnd();
      Console.Write(content);
