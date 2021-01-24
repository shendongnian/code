    public returnObject PostFromThirdPartyObject(ThirdPartyObject JSONobj)
    {
        var content = new System.IO.StreamReader(HttpContext.Current.Request.InputStream /*, Encoding here if necessary */)
                        .ReadToEnd();
    
        // Process Object
        return returnObject;
    }
