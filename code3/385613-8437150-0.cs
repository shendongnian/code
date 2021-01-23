    // Create a request to a URL
    WebRequest myReq = WebRequest.Create(url);
    string usernamePassword = "username:password";
    //Use the CredentialCache so we can attach the authentication to the request
    CredentialCache mycache = new CredentialCache();
    mycache.Add(new Uri(url), "Basic", new NetworkCredential("username", "password"));
    myReq.Credentials = mycache;
    myReq.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(usernamePassword)));
    //Send and receive the response
    WebResponse wr = myReq.GetResponse();
    Stream receiveStream = wr.GetResponseStream();
    StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
    string content = reader.ReadToEnd();
