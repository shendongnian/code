    try
    {
        if (!string.IsNullOrEmpty(url))
        {
            if (!url.StartsWith("http://") || 
                !url.StartsWith("https://"))
            {
                //At least attempt a non-SSL request 
                //if the protocol prefix was missing.
                url = string.Format("http://{0}", url);
            }
            Uri uri = new Uri(url);
            HttpWebRequest request = HttpWebRequest.Create(uri);
            HttpWebResponse response = request.GetResponse();
            if (response.StatusCode == StatusCode.NotFound)
            {
                _txbl.Text = "Broken - 404 Not Found";
            }
             if (response.StatusCode == StatusCode.OK)
            {
                _txbl.Text =  "URL appears to be good.";
            }
            else //There are a lot of other status codes you could check for...
            {
                _txbl.Text = string.Format("URL might be ok. Status: {0}.",
                                           response.StatusCode.ToString();
            }
        }
    }
    catch (Exception ex)
    {
        _txbl.Text = string.Format("Broken- Other error: {0}", ex.Message);
    }
