    public void plesni()
    {
        try
        {
        dynamic parameters = new ExpandoObject();
        parameters.message = "xxxxxxx";
        parameters.link = "xxxxxxxx";
        // parameters.picture=""
        parameters.name = "xxxxxx";
        parameters.caption = "xxxxxxx";
        parameters.description = "xxxxxxxxxx";
        parameters.actions = new
        {
            name = "xxxxxxx",
            link = "http://www.xxxxxxxxxxxxxx.com",
        };
        parameters.privacy = new
        {
            value = "ALL_FRIENDS",
        };
        parameters.targeting = new
        {
            countries = "US",
            regions = "6,53",
            locales = "6",
        };
     
        dynamic result = app.Api("/uid/feed/", parameters, HttpMethod.Post);
      //  app.Api("/uid/feed", parameters);
            Response.Write("Sucess");
        }
        catch (FacebookOAuthException)
        {
            Response.Write("...... <br/>");
        }
    }
