    public static bool TryGetRedirectedUri(Uri uri, out Uri redirectedUri)
    {
        var request = (HttpWebRequest)WebRequest.Create(uri);
        request.AllowAutoRedirect = false;
        using (var response = (HttpWebResponse)request.GetResponse())
        {
            if (response.StatusCode == HttpStatusCode.Moved)
            {
                redirectedUri = new Uri(response.Headers[HttpResponseHeader.Location]);
                return true;
            }
    
            else
            {
                redirectedUri = null;
                return false;
            }
        }
    }
