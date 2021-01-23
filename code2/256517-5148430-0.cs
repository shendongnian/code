    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
            Dim er = HttpContext.Current.Error
            If er.GetType.Equals(GetType(System.Security.SecurityException)) Then
                HttpContext.Current.Response.Redirect(FormsAuthentication.LoginUrl & "?ReturnUrl=" & HttpContext.Current.Request.Path)
            End If
        End Sub
