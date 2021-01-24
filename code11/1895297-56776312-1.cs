    public IHttpActionResult Get()
    {
        var systemID = Authenticator.AuthenticateUser(Request);
        if (systemID == 0)
            return Unauthorized();
        var dc = DataContextFactory.GeneralDataContext(ConnectionStrings.GetSystemConnectionString(systemID));
        return this.Ok(dc.GetPersonList(null, null, null, null, null, null));
    }
