            var cookies = new CookieContainer();
            ServicePointManager.Expect100Continue = false;
            CookieCollection receivedCookies = new CookieCollection();
            try
            {
                var request = (HttpWebRequest) WebRequest.Create(ServerUrl + "index.php");
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.CookieContainer = cookies;
                string postData = "try=&username=someLogin&password=somepass";
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentLength = byteArray.Length;
                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }
                // Get the response.
                using (WebResponse response = request.GetResponse())
                {
                    receivedCookies = ((HttpWebResponse) response).Cookies;
                    Logger.DebugFormat("received {0} cookies", receivedCookies.Count);
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            string responseFromServer = reader.ReadToEnd();
                            Logger.DebugFormat("response from server after login-post: {0}", responseFromServer);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.FatalFormat("there was an exception during login: {0}", ex.Message);
                return (int) CreateResult.GenericError;
            }
