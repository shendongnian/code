    XElement userElement = users.Descendants("user").FirstOrDefault();
    if (userElement != null)
    {
        UserInfo user = new UserInfo
        {
            Name = (string)userElement .Attribute("name"),
            Password = (string)userElement .Attribute("password"),
            Email = (string)userElement .Attribute("email")
        };
    }
