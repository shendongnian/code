    bool IsWebsiteUp(Uri uri)
    {
        try
        {
            var request = System.Net.WebRequest.Create(uri);
            request.Method = "HEAD";
            var response = (HttpWebResponse)request.GetResponse();
            return response.StatusCode == HttpStatusCode.OK;
        }
        catch
        {
            return false;
        }
    }
