    If needsSSL <> Request.IsSecureConnection Then
        If needsSSL Then
            Response.Redirect(Uri.UriSchemeHttps + Uri.SchemeDelimiter + Request.Url.Host +  Request.Url.PathAndQuery, True)
        Else
            Response.Redirect(Uri.UriSchemeHttp + Uri.SchemeDelimiter + Request.Url.Host + Request.Url.PathAndQuery, True)
        End If
    End If
