    [WebGet(UriTemplate ="{email}")]
    public string GetString(string email)
    {
         return "the email address is :" + email;
    }
