vb.net
Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
    If Not User.IsAuthenticated()
        ' The user actually isn't authenticated; send them to login
        Response.Redirect("login.aspx")
    End If
    If User.GetSomeClaimThatShouldBeHere() Is Nothing
        ' The second redirect that somehow makes this work
        Response.Redirect("profile.aspx")
    End If
    ' Do the rest of the page load that depends on the user claims
End Sub
If we didn't already use a catch-all page after the login, we could make a dummy page that handles the redirect logic like this:
vb.net
Public Class LoginRedirect
    Inherits Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not User.IsAuthenticated()
            ' The user actually isn't authenticated; send them to login
            Response.Redirect("login.aspx")
        End If
        If User.GetSomeClaimThatShouldBeHere() Is Nothing
            ' The second redirect that somehow makes this work
            Response.Redirect("loginredirect.aspx")
        End If
        If Not String.IsNullOrWhiteSpace(Request.QueryString("returnUrl"))
            ' Redirect to a return URL you've been passing around
            Response.Redirect(Request.QueryString("returnUrl"))
        End If
        ' Do some other logic to determine where the user (with all their claims available) needs to go
    End Sub
End Class
I'm not going to mark this at the accepted answer for a while in case someone comes up with a better solution than to do a seemingly superfluous redirect.
