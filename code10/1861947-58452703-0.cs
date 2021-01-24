    string authHeader = Request.Headers["Authorization"];
    if (authHeader != null && authHeader.StartsWith("Basic"))
    {
        string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
        Encoding encoding = Encoding.GetEncoding("iso-8859-1");
        string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));
         int seperatorIndex = usernamePassword.IndexOf(':');
         var clientId = usernamePassword.Substring(0, seperatorIndex);
         var clientSecret = usernamePassword.Substring(seperatorIndex + 1);
    }
