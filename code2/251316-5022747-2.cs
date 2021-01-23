    using (var client = new WebClient())
    {
        var fields = new NameValueCollection
        {
            { "SiteAbbreviation", "ABCD" },
            { "Username", "username" },
            { "Password", "password" },
            { "AdminPassword", "password" }
        };
        byte[] result = client.UploadValues(
            "http://foo.com/someController/authenticate", 
            fields
        );
        // TODO: do something with the result
        // if it is a JSON object deserialize it back to a model
    }
