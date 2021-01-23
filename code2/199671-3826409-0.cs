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
                _txbl.Text = "Broken - Not Found";
            }
            if (response != null)
            {
                _txbl.Text = "GOOD";
            }
        }
    }
    catch (Exception ex)
    {
        _txbl.Text = "BROKEN - Other error";
    }
