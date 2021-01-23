    HttpStatusCode GetHttpStatusCode(WebException we)
    {
        if (we.Response is HttpWebResponse)
        {
            HttpWebResponse response = (HttpWebResponse)we.Response;
            return response.StatusCode;
        }
        return 0;
    }
