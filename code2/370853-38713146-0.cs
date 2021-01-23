    private const string key = "xxxxxInsertGoogleAPIKeyHerexxxxxxxxxx";
    public string urlShorter(string url)
    {
                string finalURL = "";
                string post = "{\"longUrl\": \"" + url + "\"}";
                string shortUrl = url;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/urlshortener/v1/url?key=" + key);
                try
                {
                    request.ServicePoint.Expect100Continue = false;
                    request.Method = "POST";
                    request.ContentLength = post.Length;
                    request.ContentType = "application/json";
                    request.Headers.Add("Cache-Control", "no-cache");
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        byte[] postBuffer = Encoding.ASCII.GetBytes(post);
                        requestStream.Write(postBuffer, 0, postBuffer.Length);
                    }
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            using (StreamReader responseReader = new StreamReader(responseStream))
                            {
                                string json = responseReader.ReadToEnd();
                                finalURL = Regex.Match(json, @"""id"": ?""(?.+)""").Groups["id"].Value;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // if Google's URL Shortener is down...
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                }
                return finalURL;
    }
