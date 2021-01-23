        static bool UrlExists(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "HEAD";
                request.AllowAutoRedirect = false;
                request.GetResponse();
            }
            catch (UriFormatException)
            {
                // Invalid Url
                return false;
            }
            catch (WebException ex)
            {
                // Valid Url but not exists
                HttpWebResponse webResponse = (HttpWebResponse)ex.Response;
                if (webResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }
            }
            return true;
        }
