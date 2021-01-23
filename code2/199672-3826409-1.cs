    try
    {
        if (!string.IsNullOrEmpty(url))
        {
            Uri uri = new Uri(url);
            HttpWebRequest request = new HttpWebRequest();
            request.Address = uri;
            HttpWebResponse response = request.GetResponse();
            if (response.StatusCode == NotFound)
            {
                _txbl.Text = "Broken - 404 Not Found";
            }
            if (response != null)
            {
                _txbl.Text = "URL is good.";
            }
        }
    }
    catch (Exception ex)
    {
        _txbl.Text = string.Format("BROKEN - Other error: {0}", ex.Message);
    }
