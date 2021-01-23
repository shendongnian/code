     POST http://maps.google.com/maps/feeds/maps/default/full
    GData-Version: 2.0
    Authorization: GoogleLogin auth="authorization_token"
    Content-Type: text/csv
    Slug: A new map
    
    name,latitude,longitude,description
    Hello,-77.066395,-11.968312,Greetings from Lima!
    There,145.34502,-38.51512,Out There Down Under
    How,-88.421001,44.970465,How is Wisconsin?
    Are,13.084501,63.399164,Sorry about that
    You,140.637898,42.842568,I love you Hokkaido
    
    
        public static class ClientLogin
        {
            /// <summary>
            /// Client login url where we'll post login data to.
            /// </summary>
            private static string clientLoginUrl = 
                @"https://www.google.com/accounts/ClientLogin";
    
            /// <summary>
            /// Data to be sent with the post request.
            /// </summary>
            private static string postData = 
                @"service={0}&continue=http://www.google.com/&Email={1}&Passwd={2}&source={3}";
    
            /// <summary>
            /// Get the Auth token you get after a successful login. 
            /// You'll need to reuse this token in the header of each new request you make.
            /// </summary>
            /// <param name="service"></param>
            /// <param name="username"></param>
            /// <param name="password"></param>
            /// <param name="source"></param>
            /// <returns></returns>
            public static string GetAuthToken(
                string service, string username, string password, string source)
            {
                // Get the response that needs to be parsed.
                string response = PostRequest(service, username, password, source);
    
                // Get auth token.
                string auth = ParseAuthToken(response);
                return auth;
            }
    
            /// <summary>
            /// Parse the Auth token from the response.
            /// </summary>
            /// <param name="response"></param>
            /// <returns></returns>
            private static string ParseAuthToken(string response)
            {            
                // Get the auth token.
                string auth = "";
                try
                {
                    auth = new Regex(@"Auth=(?<auth>\S+)").Match(response).Result("${auth}");
                }
                catch (Exception ex)
                {
                    throw new AuthTokenException(ex.Message);
                }
    
                // Validate token.
                if (string.IsNullOrEmpty(auth))
                {
                    throw new AuthTokenException("Missing or invalid 'Auth' token.");
                }
    
                // Use this token in the header of each new request.
                return auth;
            }
    
            /// <summary>
            /// Create a post request with all the login data. This will return something like:
            /// 
            /// SID=AQAAAH1234
            /// LSID=AQAAAH8AA5678
            /// Auth=AQAAAIAAAAB910
            /// 
            /// And we need the Auth token for each subsequent request.
            /// </summary>
            /// <param name="service"></param>
            /// <param name="email"></param>
            /// <param name="password"></param>
            /// <param name="source"></param>
            /// <returns></returns>
            private static string PostRequest(
                string service, string email, string password, string source)
            {
                // Get the current post data and encode.
                ASCIIEncoding ascii = new ASCIIEncoding();
                byte[] encodedPostData = ascii.GetBytes(
                    String.Format(postData, service, email, password, source));
                
                // Prepare request.
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(clientLoginUrl);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = encodedPostData.Length;
    
                // Write login info to the request.
                using (Stream newStream = request.GetRequestStream())
                    newStream.Write(encodedPostData, 0, encodedPostData.Length);
    
                // Get the response that will contain the Auth token.
                HttpWebResponse response = null;
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException ex)
                {
                    HttpWebResponse faultResponse = ex.Response as HttpWebResponse;
                    if (faultResponse != null && faultResponse.StatusCode == HttpStatusCode.Forbidden)
                        throw new IncorrectUsernameOrPasswordException(
                            faultResponse.StatusCode, faultResponse.StatusDescription);
                    else
                        throw;
                }
    
                // Check for login failed.
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new LoginFailedException(
                        response.StatusCode, response.StatusDescription);
    
                // Read.
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    return reader.ReadToEnd();
            }
        }
    
     string auth = ClientLogin.GetAuthToken("local", "username", "password", "");
    
    UploadCSV(auth )
    
     public  string UploadCSV(string auth)
            {
                string URI = "http://maps.google.com/maps/feeds/maps/default/full";
    
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(URI);
                //Add these, as we're doing a POST
    
                req.KeepAlive = false;
                req.Method = "POST";
                req.Headers.Add("GData-Version", "2.0");
                req.Headers.Add("Slug", "A new map");
    
                req.Headers.Add("Authorization", "GoogleLogin auth=" + auth);
                FileStream fs = new FileStream("E:\\Surajit\\MapPoint\\1.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                req.ContentLength = fs.Length;
                req.ContentType = "text/csv";
                Stream outputStream = req.GetRequestStream();
    
                WriteInputStreamToRequest(fs, outputStream);
    
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                outputStream.Close();
                fs.Close();
                if (resp == null) return null;
                StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                return sr.ReadToEnd().Trim();
            }
    protected void WriteInputStreamToRequest(Stream input, Stream output)
            {
                BinaryWriter w = new BinaryWriter(output);
                const int size = 4096;
                byte[] bytes = new byte[4096];
                int numBytes;
    
                while ((numBytes = input.Read(bytes, 0, size)) > 0)
                {
                    w.Write(bytes, 0, numBytes);
                }
                w.Flush();
            }
