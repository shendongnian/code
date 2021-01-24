      class RestTiming
      {
        public string endPoint { get; set; }
        public string token { get; set; }
        public httpVerb httpMethod { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string postJSON { get; set; }
        public RestTiming()
        {
            endPoint = string.Empty;
            token = string.Empty;
        }
        public async Task<string> makeRequest() //1. Changed to async and return type
        {
            if (InternetAvailable())
            {
                string strResponseValue = string.Empty;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
                request.Method = httpMethod.ToString();
                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Headers.Add("Authorization", token);
                request.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36";
                if ((request.Method == "POST" || request.Method == "PUT") && postJSON != string.Empty)
                {
                    using (StreamWriter swJSONPayload = new StreamWriter(await request.GetRequestStreamAsync())) //2. changed to asynchronous call
                    {
                        swJSONPayload.Write(postJSON);
                        swJSONPayload.Close();
                    }
                }
                WebResponse response = null; //(a) updated
                try
                {
                    response =await request.GetResponseAsync(); 
                    // Process the response stream... (could be JSON, XML or HTML etc...)
                    using (Stream responseStream =response.GetResponseStream()) //(b) updated
                    {
                        if (responseStream != null)
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                strResponseValue = await reader.ReadToEndAsync(); // (c) updated
                            }// End of StreamReader
                        }
                    }// End of using ResponseStream
                }
                catch (WebException ex)
                {
                    if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
                    {
                        var resp = (HttpWebResponse)ex.Response;
                        if (resp.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            MessageBox.Show("Unauthorized", "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Environment.Exit(1);
                        }
                    }
                }
                return strResponseValue;
            }
            else
            {
                return null;
            }
        }
        private static Boolean InternetAvailable()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    using (client.OpenRead("http://www.google.com/"))
                    {
                        return true;
                    }
                }
            }
