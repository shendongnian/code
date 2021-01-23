    FacebookApp facebook = new FacebookApp(GetFacebookSettings());
    if (facebook.Session != null)
    {
        dynamic parameters = new ExpandoObject();
        parameters.fields = "id,first_name,last_name,birthday,email";
        dynamic result = facebook.Api("me", parameters);
        // do something with the user's name...
        string firstName = result.first_name;
    }
