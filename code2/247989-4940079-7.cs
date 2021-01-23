    Dim authTicket As System.Web.Security.FormsAuthenticationTicket = _
            New System.Web.Security.FormsAuthenticationTicket( _
                1, _
                UserName, _
                Now, _
                Now.AddYears(100), _
                createPersistentCookie, _
                UserData)
    Dim encryptedTicket As String = System.Web.Security.FormsAuthentication.Encrypt(authTicket)
    Dim authCookie As HttpCookie = New HttpCookie( _
        System.Web.Security.FormsAuthentication.FormsCookieName, _
        encryptedTicket)
    If (createPersistentCookie) Then
        authCookie.Expires = authTicket.Expiration
    End If
    Response.Cookies.Add(authCookie)
