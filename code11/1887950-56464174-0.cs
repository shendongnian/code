    using (var wc = new WebClient())
    {
        wc.Headers["Authorization"] = string.Format("Basic {0}", ConfigurationManager.AppSettings["which_api_token"]);
        try
        {
            var jsonString = wc.DownloadString(string.Format("{0}/subjects/{1}", 
                    ConfigurationManager.AppSettings["which_api_url"], 
                    Uri.EscapeDataString(subjectName)));
            return result;
        }
        catch(Exception ex)
        {
            WebException we = ex as WebException;
            if (we != null && we.Response is HttpWebResponse)
            {
                HttpWebResponse response = (HttpWebResponse)we.Response;
                // it can be 404, 500 etc...
                Console.WriteLine(response.StatusCode);
            }
            result.Status = ResultStatus.Failed;
            return result;
        }
    }
