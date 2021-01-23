        /// <summary>
        /// Send error report (exception) to HTTP endpoint.
        /// </summary>
        /// <param name="uri">The Endpoint to report to.</param>
        /// <param name="exception">Exception to send.</param>
        public void SendExceptionToHttpEndpoint(string uri, ExceptionContainer exception)
        {
            if (!this.AllowAnonymousHttpReporting)
            {
                return;
            }
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.BeginGetRequestStream(
                    r =>
                    {
                        try
                        {
                            HttpWebRequest request1 = (HttpWebRequest)r.AsyncState;
                            Stream postStream = request1.EndGetRequestStream(r);
                            string info = string.Format("{0}{1}{2}{1}AppVersion: {3}{1}", exception.Message, Environment.NewLine, exception.StackTrace, exception.AppVersion);
                            string postData = "&exception=" + HttpUtility.UrlEncode(info);
                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                            postStream.Write(byteArray, 0, byteArray.Length);
                            postStream.Close();
                            request1.BeginGetResponse(
                                s =>
                                {
                                    try
                                    {
                                        HttpWebRequest request2 = (HttpWebRequest)s.AsyncState;
                                        HttpWebResponse response = (HttpWebResponse)request2.EndGetResponse(s);
                                        Stream streamResponse = response.GetResponseStream();
                                        StreamReader streamReader = new StreamReader(streamResponse);
                                        string response2 = streamReader.ReadToEnd();
                                        streamResponse.Close();
                                        streamReader.Close();
                                        response.Close();
                                    }
                                    catch
                                    {
                                    }
                                },
                            request1);
                        }
                        catch
                        {
                        }
                    },
                webRequest);
            }
            catch
            {
            }
        }
