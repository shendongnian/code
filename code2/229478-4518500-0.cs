            try
            {
                webresponse = (System.Net.HttpWebResponse)req.GetResponse();
            }
            catch (Exception ex)
            {
                webresponse = null;
                Console.Write("request for url failed: {0} {1}", url, ex.Message);
            }
            if (webresponse != null)
            {
                webresponse.Cookies = req.CookieContainer.GetCookies(req.RequestUri);
                // handle cookies (need to do this incase we have any session cookies)
                foreach (System.Net.Cookie retCookie in webresponse.Cookies)
                {
                    bool cookieFound = false;
                    foreach (System.Net.Cookie oldCookie in _CookieContainer.GetCookies(uri))
                    {
                        if (retCookie.Name.Equals(oldCookie.Name))
                        {
                            oldCookie.Value = retCookie.Value;
                            cookieFound = true;
                        }
                    }
                    if (!cookieFound)
                    {
                        _CookieContainer.Add(retCookie);
                    }
                }
