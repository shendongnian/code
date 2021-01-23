    private String m_HeaderName;
    private String m_HeaderValue;
    //----------------
    // GetWebRequest
    //
    // Called by the SOAP client class library
    //----------------   
    protected override WebRequest GetWebRequest(Uri uri)
    {
        // call the base class to get the underlying WebRequest object
        HttpWebRequest req = (HttpWebRequest)base.GetWebRequest(uri);
        if (null != this.m_HeaderName)
        {
            // set the header
            req.Headers.Add(this.m_HeaderName, this.m_HeaderValue);
        }
        // return the WebRequest to the caller
        return (WebRequest)req;
    }
    //----------------
    // SetRequestHeader
    //
    // Sets the header name and value that GetWebRequest will add to the
    // underlying request used by the SOAP client when making the 
    // we method call
    //----------------   
    public void SetRequestHeader(String headerName, String headerValue)
    {
        this.m_HeaderName = headerName;
        this.m_HeaderValue = headerValue;
    }
