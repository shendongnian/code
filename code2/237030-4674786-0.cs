    public NameValueCollection QueryString
    {
        get
        {
            NameValueCollection nvc = new NameValueCollection();
            Helpers.FillFromString(nvc, this.Url.Query, true, this.ContentEncoding);
            return nvc;
        }
    }
