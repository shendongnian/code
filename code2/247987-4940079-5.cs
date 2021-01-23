    Public Function ReadCookieAuthentication(ByVal Context As System.Web.HttpContext) As Security.CookieAuth
        Dim CookieUserData = New Security.CookieAuth()
        Dim cookieName As String = System.Web.Security.FormsAuthentication.FormsCookieName
        Dim authCookie As HttpCookie = Context.Request.Cookies(cookieName)
        If (Not (authCookie Is Nothing)) Then
            Dim authTicket As System.Web.Security.FormsAuthenticationTicket = Nothing
            Try
                authTicket = System.Web.Security.FormsAuthentication.Decrypt(authCookie.Value)
                If (Not (authTicket Is Nothing)) Then
                    If (authTicket.UserData IsNot Nothing) AndAlso Not String.IsNullOrEmpty(authTicket.UserData) Then
                        CookieUserData = New JavaScriptSerializer().Deserialize(Of Security.CookieAuth)(authTicket.UserData.ToString)
                    End If
                    CookieUserData.UserName = authTicket.Name
                End If
            Catch ex As Exception
                ' Do nothing.
            End Try
        End If
        Return (CookieUserData)
    End Function
