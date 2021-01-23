    Dim tUriPath As String = "/mysite/secondary.aspx?id=1005"
    Dim tURI As Uri = New Uri("dummy://example.com" & tUriPath)
    Dim tIdValue As String = System.Web.HttpUtility.ParseQueryString(tUri.Query)
    
    Dim theIntYouWant as String= System.Web.HttpUtility.ParseQueryString(tUri.Query)("id")
