    var ticketData = new NameValueCollection
    {
        { "name", user.FullName },
        { "emailAddress", user.EmailAddress }
    };
    new FormsAuthentication().SetAuthCookie(user.UserId, true, ticketData); 
