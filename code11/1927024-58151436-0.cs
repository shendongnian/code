            HttpWebResponse response = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AllowWriteStreamBuffering = false;
                request.Headers.Set(HttpRequestHeader.CacheControl, "max-age=0");
                request.Headers.Add("Upgrade-Insecure-Requests", @"1");
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.132 Safari/537.36 OPR/63.0.3368.88";
                response = (HttpWebResponse)request.GetResponse();
                string _responseData;
                using(StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                   _responseData = sr.ReadToEnd();
                }
            }
            catch (WebException e)
            {
            }
            catch (UriFormatException p)
            {
            }
            finally
            {
                   response.Close();
            }
