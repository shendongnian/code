    var customProperties = new Dictionary<string, string>();
    customProperties.Add("as:client_id", context.ClientId ?? string.Empty);
    customProperties.Add("user_roles", user_roles);
    customProperties.Add("user_timezone", timeZoneName);
    customProperties.Add("user_country", account.CountryCode ?? string.Empty);
                   
    AuthenticationProperties properties = new AuthenticationProperties(customProperties);
    AuthenticationTicket ticket = new AuthenticationTicket(identity, properties);
    context.Validated(ticket);
