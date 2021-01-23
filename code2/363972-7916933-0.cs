    class HTTPHandler
    {
        // Some default settings
        const string UserAgent = "Bot"; // Change this to something more meaningful
        const int TimeOut = 1000; // Time out in ms
        // Basic connection
        public static string Connect(string url)
        {
            return Connect(url, "", "", UserAgent, "", TimeOut);
        }
        // Connect with post data passed as a key : value pair dictionary
        public static string Connect(string url, Dictionary<string, string> args)
        {
            return Connect(url, "", "", UserAgent, ToQueryString(args), TimeOut);
        }
        // Connect with a custom user agent specified
        public static string Connect(string url, string userAgent)
        {
            return Connect(url, "", "", userAgent, "", TimeOut);
        }
        public static string Connect(string url, string userName, string password, string userAgent, string postData, int timeOut)
        {
            string result;
            try
            {
                // Create a request for the URL. 		
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                if (userAgent == null)
                    userAgent = UserAgent;
                request.UserAgent = userAgent;
                request.Timeout = timeOut;
                if (userName.Length > 0)
                {
                    string authInfo = userName + ":" + password;
                    authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                    request.Headers["Authorization"] = "Basic " + authInfo;
                    request.AllowAutoRedirect = false;
                }
                if (postData.Length > 0)
                {
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    // Create POST data and convert it to a byte array.
                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    request.ContentLength = byteArray.Length;
                    using (Stream dataStream = request.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                    }
                }
                // Get the response.
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    // Get the stream containing content returned by the server.
                    Stream dataStream = response.GetResponseStream();
                    // Open the stream using a StreamReader for easy access.
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        result = string.Format("Server response:\n{0}\n{1}", response.StatusDescription, reader.ReadToEnd());
                    }
                }
            }
            catch (Exception e)
            {
                result = string.Format("There was an error:\n{0}", e.Message);
            }
            return result;
        }
        public static string ToQueryString(Dictionary<string, string> args)
        {
            List<string> encodedData = new List<string>();
            foreach (KeyValuePair<string, string> pair in args)
            {
                encodedData.Add(HttpUtility.UrlEncode(pair.Key) + "=" + HttpUtility.UrlEncode(pair.Value));
            }
            return String.Join("&", encodedData.ToArray());
        }
    }
