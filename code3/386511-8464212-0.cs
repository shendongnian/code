    public string GetRootUrl(string url)
    {
       Uri uri = new Uri(str);
       return string.Format("{0}://{1}", uri.Scheme, uri.Authority);
    }
