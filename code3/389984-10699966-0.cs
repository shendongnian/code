    private Dictionary<int, CookieContainer> m_cookieContainer = new Dictionary<int, CookieContainer>();
    private void Button_Click(object sender, RoutedEventArgs e)
            {
                HttpWebRequest req = CreateRequest("http://vimeo.com/42082443");
                req.AllowAutoRedirect = false;
                req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:12.0) Gecko/20100101 Firefox/12.0";
                req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                req.Headers[HttpRequestHeader.AcceptLanguage] = "ru,en;q=0.8,en-us;q=0.5,uk;q=0.3";
                req.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate";
                req.KeepAlive = true;
                req.Timeout = 20000;
                req.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpWebResponse response = GetResponse(req))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string pageData = new StreamReader(response.GetResponseStream()).ReadToEnd();
    
                        string clipId = null;
                        if (Regex.Match(pageData, @"clip_id=(\d+)", RegexOptions.Singleline).Success)
                        {
                            clipId = Regex.Match(pageData, @"clip_id=(\d+)", RegexOptions.Singleline).Groups[1].ToString();
                        }
                        else if (Regex.Match(pageData, @"(\d+)", RegexOptions.Singleline).Success)
                        {
                            clipId = Regex.Match(pageData, @"(\d+)", RegexOptions.Singleline).Groups[1].ToString();
                        }
    
                        string sig = Regex.Match(pageData, "\"signature\":\"(.+?)\"", RegexOptions.Singleline).Groups[1].ToString();
                        string timestamp = Regex.Match(pageData, "\"timestamp\":(\\d+)", RegexOptions.Singleline).Groups[1].ToString();
    
                        string videoUrl = string.Format("http://player.vimeo.com/play_redirect?clip_id={0}&sig={1}&time={2}&quality=hd&codecs=H264,VP8,VP6&type=moogaloop_local&embed_location=", clipId, sig, timestamp);
    
                        req = CreateRequest(videoUrl);
                        req.AllowAutoRedirect = false;
                        req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:12.0) Gecko/20100101 Firefox/12.0";
                        req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                        req.Headers[HttpRequestHeader.AcceptLanguage] = "ru,en;q=0.8,en-us;q=0.5,uk;q=0.3";
                        req.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate";
                        req.KeepAlive = true;
                        req.Referer = "http://a.vimeocdn.com/p/flash/moogaloop/5.2.25/moogaloop.swf?v=1.0.0";
                        req.Timeout = 20000;
                        req.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                        using (HttpWebResponse response2 = GetResponse(req))
                        {
                            if (response2.StatusCode == HttpStatusCode.Found)
                            {
                                string location = response2.Headers[HttpResponseHeader.Location];
                                MessageBox.Show(location);
                            }
                        }
                    }
                }
            }
    
            private CookieContainer GetCookieContainerPerThread()
            {
                int managedThreadId = Thread.CurrentThread.ManagedThreadId;
                lock (typeof(MainWindow))
                {
                    if (!this.m_cookieContainer.ContainsKey(managedThreadId))
                    {
                        CookieContainer container = new CookieContainer();
                        this.m_cookieContainer.Add(managedThreadId, container);
                    }
                }
                return this.m_cookieContainer[managedThreadId];
            }
    
            public HttpWebRequest CreateRequest(string url)
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.CookieContainer = this.GetCookieContainerPerThread();
                //this.InitProxy(req);
                return req;
            }
    
            public HttpWebResponse GetResponse(HttpWebRequest req)
            {
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                this.GetCookieContainerPerThread().Add(response.Cookies);
                return response;
            }
