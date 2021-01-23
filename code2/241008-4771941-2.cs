    void SomeWebMethodThatRequiresAuthentication(someparameter)
    {
        if (HttpContect.Current.User.IsAuthenticated)
        {
            ... do whatever you need - user is logged in ...
        }
        else
        {
            .... optionally let user know he is not logged in ...
        }
    }
