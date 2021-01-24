    Public Sub Configuration(ByVal app As IAppBuilder)
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType)
            app.UseCookieAuthentication(New CookieAuthenticationOptions())
            app.UseOpenIdConnectAuthentication(New OpenIdConnectAuthenticationOptions With {
                .ClientId = clientId,
                .Authority = authority,
                .RedirectUri = redirectUri,
                .PostLogoutRedirectUri = redirectUri,
                .Scope = OpenIdConnectScope.OpenIdProfile,
                .ResponseType = OpenIdConnectResponseType.IdToken,
                .TokenValidationParameters = New TokenValidationParameters() With {
                    .ValidateIssuer = True
                },
                .Notifications = New OpenIdConnectAuthenticationNotifications With {
                    .AuthenticationFailed = Function(context)
                                                context.HandleResponse()
                                                context.Response.Redirect(HttpContext.Current.Server.MapPath("~") & "?errormessage=" & context.Exception.Message)
                                                Return Task.FromResult(0)
                                            End Function
                }
            })
    End Sub
