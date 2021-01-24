    public returnObject PostFromThirdPartyObject(ThirdPartyObject JSONobj)
    {
        if (!ModelState.IsValid)
        {
            var content = new StreamReader(HttpContext.Current.Request.InputStream /*, Encoding here if necessary */)
                    .ReadToEnd();
            // Do something with the raw content here
            return BadRequest(ModelState);
        }
    
        // Process Object
        return returnObject;
    }
