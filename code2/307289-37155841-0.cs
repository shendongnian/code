    try
                {
                    response = (HttpWebResponse) webRequest.GetResponse();
                }
                catch (WebException ex)
                {
                    using (var sr = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        var html = sr.ReadToEnd();
                    }
                }
