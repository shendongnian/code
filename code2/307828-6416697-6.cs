    public static void ReWriteAuthTicket(HttpCookie cookie, string roles)
    {
        FormsAuthenticationTicket ft = FormsAuthentication.Decrypt(cookie.Value);
    
        // Use the existing ticket to make a new one with the embedded UserData
        FormsAuthenticationTicket newFt =
            new FormsAuthenticationTicket(ft.Version,
                ft.Name,
                ft.IssueDate,
                ft.Expiration,
                ft.IsPersistent,
                roles,
                ft.CookiePath);
    
        //re-encrypt the new forms auth ticket that includes the user data
        string encryptedValue = FormsAuthentication.Encrypt(newFt);
        cookie.Value = encryptedValue;
        cookie.Expires = (ft.IsPersistent) ? ft.Expiration : DateTime.MinValue;
        cookie.Path = ft.CookiePath;
        // Set the authentication cookie
        HttpContext.Current.Response.Cookies.Add(cookie);
    }
