vb.net
Dim userManager = Context.GetOwinContext().GetUserManager(Of UserManager)
Dim authenticatingUser = userManager.Find(UserID_TB.Text, PW_TB.Text)
If authenticatingUser Is Nothing
    SetMessage("Failed")
    Return
End If
userManager.UpdateSecurityStamp(authenticatingUser.Id)
Dim userIdentity = authenticatingUser.GenerateIdentityAsync(userManager).Result
Dim authenticationManager = HttpContext.Current.GetOwinContext().Authentication
authenticationManager.SignIn(
    New AuthenticationProperties With {
        .IsPersistent = RememberMe_CB.Checked
        },
    userIdentity)
Response.Redirect("profile.aspx", False)
I also wrote this to handle refreshing user claims:
vb.net
Public Shared Sub RefreshSignIn()
    Dim authenticationManager = HttpContext.Current.GetOwinContext().Authentication
    authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie)
    Dim userManager = HttpContext.Current.GetOwinContext().GetUserManager(Of UserManager)
    Dim user = userManager.FindById(HttpContext.Current.User.Identity.GetUserId())
    Dim userIdentity = user.GenerateIdentityAsync(userManager).Result
    authenticationManager.SignIn(userIdentity)
End Sub
### Original
I solved the problem by adding an additional redirect after the login. In the case of the example application I provided, we always redirect to profile, so I changed profile's Page_Load event handler to this:
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
