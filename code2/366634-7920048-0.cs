    [WebMethod(EnableSession = true)]
    public string ReadUserAdditional()
    {
        return GetUserJSON(x => new { result = true, x.Image, x.Biography });
    }
    [WebMethod(EnableSession = true]
    public string ReadUserBasicInformation()
    {
        return GetUserJSON(x => new { result = true, x.Name, x.UserName });
    }
    private string GetUserJSON(Func<EUser, string> jsonFields)
    {
        EUser user = (EUser)Session["user"];
        var json = jsonFields(user);
        return new JavaScriptSerializer().Serialize(json);
    }
