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
    string enc = "utf-8"; // default
                if (webresponse.ContentEncoding != String.Empty)
                {
                    // Use the HttpHeader Content-Type in preference to the one set in META
                    doc.Encoding = webresponse.ContentEncoding;
                }
                else if (doc.Encoding == String.Empty)
                {
                    doc.Encoding = enc; // default
                }
                //http://www.c-sharpcorner.com/Code/2003/Dec/ReadingWebPageSources.asp
                System.IO.StreamReader stream = new System.IO.StreamReader
                    (webresponse.GetResponseStream(), System.Text.Encoding.GetEncoding(doc.Encoding));
