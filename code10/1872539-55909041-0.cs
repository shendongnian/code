    Imports System.Security.Claims
	Imports System.Threading.Tasks
	Imports IdentityModel
	Imports IdentityModel.Client
	Imports Microsoft.AspNet.Identity
	Imports Microsoft.AspNet.Identity.Owin
	Imports Microsoft.IdentityModel.Protocols.OpenIdConnect
	Imports Microsoft.Owin
	Imports Microsoft.Owin.Security
	Imports Microsoft.Owin.Security.Cookies
	Imports Microsoft.Owin.Security.Notifications
	Imports Microsoft.Owin.Security.OAuth
	Imports Microsoft.Owin.Security.OpenIdConnect
	Imports Owin
	Partial Public Class Startup
		Private Shared _oAuthOptions As OAuthAuthorizationServerOptions
		Private Shared _publicClientId As String
		Private Shared _clientId As String
		Private Shared _clientSecret As String
		' Enable the application to use OAuthAuthorization. You can then secure your Web APIs
		Shared Sub New()
			_clientId = System.Configuration.ConfigurationManager.AppSettings("OAuth:ClientID").ToString()
			_clientSecret = System.Configuration.ConfigurationManager.AppSettings("OAuth:SecretKey").ToString()
			PublicClientId = _clientId
			OAuthOptions = New OAuthAuthorizationServerOptions() With {
				.TokenEndpointPath = New PathString("/Token"), 'New PathString("https://authtesteria.domain.com/as/token.oauth2"), ' 
				.AuthorizeEndpointPath = New PathString("/Account/Authorize"), 'New PathString("https://authtesteria.domain.com/as/authorization.oauth2"), '
				.Provider = New ApplicationOAuthProvider(PublicClientId),
				.AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
				.AllowInsecureHttp = True
			}
		End Sub
		Public Shared Property OAuthOptions() As OAuthAuthorizationServerOptions
			Get
				Return _oAuthOptions
			End Get
			Private Set
				_oAuthOptions = Value
			End Set
		End Property
		Public Shared Property PublicClientId() As String
			Get
				Return _publicClientId
			End Get
			Private Set
				_publicClientId = Value
			End Set
		End Property
		' For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
		Public Sub ConfigureAuth(app As IAppBuilder)
			' Configure the db context, user manager and signin manager to use a single instance per request
			app.CreatePerOwinContext(AddressOf ApplicationDbContext.Create)
			app.CreatePerOwinContext(Of ApplicationUserManager)(AddressOf ApplicationUserManager.Create)
			app.CreatePerOwinContext(Of ApplicationSignInManager)(AddressOf ApplicationSignInManager.Create)
			' Enable the application to use a cookie to store information for the signed in user
			' and to use a cookie to temporarily store inforation about a user logging in with a third party login provider
			' Configure the sign in cookie
			' OnValidateIdentity enables the application to validate the security stamp when the user logs in.
			' This is a security feature which is used when you change a password or add an external login to your account.
			app.UseCookieAuthentication(New CookieAuthenticationOptions() With {
				.AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
				.Provider = New CookieAuthenticationProvider() With {
					.OnValidateIdentity = SecurityStampValidator.OnValidateIdentity(Of ApplicationUserManager, ApplicationUser)(
						validateInterval:=TimeSpan.FromMinutes(30),
						regenerateIdentity:=Function(manager, user) user.GenerateUserIdentityAsync(manager))},
				.LoginPath = New PathString("/Account/Login")})
			app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie)
			' Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
			app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5))
			' Enables the application to remember the second login verification factor such as phone or email.
			' Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
			' This is similar to the RememberMe option when you log in.
			app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie)
			' Enable the application to use bearer tokens to authenticate users
			app.UseOAuthBearerTokens(OAuthOptions)
			Dim controller As New AccountController()
			'Dim validator As OpenIdConnectProtocolValidator = New OpenIdConnectProtocolValidator()
			'validator.ShowPII = False
			Dim oidcAuth As New Microsoft.Owin.Security.OpenIdConnect.OpenIdConnectAuthenticationOptions() With {
				.ClientId = _clientId,
				.ClientSecret = _clientSecret,
				.Authority = "https://authtesteria.domain.com",
				.Notifications = New Microsoft.Owin.Security.OpenIdConnect.OpenIdConnectAuthenticationNotifications() With {
					.RedirectToIdentityProvider = AddressOf OnRedirectToIdentityProvider,
					.MessageReceived = AddressOf OnMessageReceived,
					.SecurityTokenReceived = AddressOf OnSecurityTokenReceived,
					.SecurityTokenValidated = AddressOf OnSecurityTokenValidated,
					.AuthorizationCodeReceived = AddressOf OnAuthorizationCodeReceived,
					.AuthenticationFailed = AddressOf OnAuthenticationFailed
			}}
			app.UseOpenIdConnectAuthentication(oidcAuth)
		End Sub
		Private Function OnRedirectToIdentityProvider(arg As RedirectToIdentityProviderNotification(Of Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage, OpenIdConnectAuthenticationOptions)) As Task
			Debug.WriteLine("*** RedirectToIdentityProvider")
			If arg.ProtocolMessage.RequestType = Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectRequestType.Logout Then
				Dim idTokenHint = arg.OwinContext.Authentication.User.FindFirst("id_token")
				If idTokenHint IsNot Nothing Then
					arg.ProtocolMessage.IdTokenHint = idTokenHint.Value
				End If
			End If
			Return Task.FromResult(0)
		End Function
		Private Function OnMessageReceived(arg As MessageReceivedNotification(Of Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage, OpenIdConnectAuthenticationOptions)) As Task
			Debug.WriteLine("*** MessageReceived")
			Return Task.FromResult(0)
		End Function
               
		Private Function OnAuthorizationCodeReceived(arg As AuthorizationCodeReceivedNotification) As Task
			Debug.WriteLine("*** AuthorizationCodeReceived")
			'Upon successful sign in, get & cache a token if you want here
			Return Task.FromResult(0)
		End Function
		Private Function OnAuthenticationFailed(arg As AuthenticationFailedNotification(Of Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage, OpenIdConnectAuthenticationOptions)) As Task
			Debug.WriteLine("*** AuthenticationFailed")
			Return Task.FromResult(0)
		End Function
		Private Function OnSecurityTokenReceived(arg As SecurityTokenReceivedNotification(Of Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage, OpenIdConnectAuthenticationOptions)) As Task
			Debug.WriteLine("*** SecurityTokenReceived")
			Return Task.FromResult(0)
		End Function
		Private Async Function OnSecurityTokenValidated(arg As SecurityTokenValidatedNotification(Of Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage, OpenIdConnectAuthenticationOptions)) As Task
			Debug.WriteLine("*** SecurityTokenValidated")
			'Verify the user signing in should have access or not.  Here I just pass folk thru.
			Dim nid = New ClaimsIdentity(
				  DefaultAuthenticationTypes.ApplicationCookie, 'arg.AuthenticationTicket.Identity.AuthenticationType,
				  ClaimTypes.GivenName,
				  ClaimTypes.Role)
			Dim tokenClient = New TokenClient("https://authtesteria.domain.com/as/token.oauth2",
				 _clientId,
				 _clientSecret)
			Dim tokenResponse = Await tokenClient.RequestAuthorizationCodeAsync(arg.ProtocolMessage.Code, arg.ProtocolMessage.RedirectUri)
			' get userinfo data
			Dim userInfoClient = New IdentityModel.Client.UserInfoClient("https://authtesteria.domain.com/idp/userinfo.openid")
			Dim userInfo = Await userInfoClient.GetAsync(tokenResponse.AccessToken)
			userInfo.Claims.ToList().ForEach(Sub(ui) nid.AddClaim(New Claim(ui.Type, ui.Value)))
			'' keep the id_token for logout
			'nid.AddClaim(New Claim("id_token", arg.ProtocolMessage.IdToken))
			'' add access token for sample API
			'nid.AddClaim(New Claim("access_token", arg.ProtocolMessage.AccessToken))
			'' keep track of access token expiration
			'nid.AddClaim(New Claim("expires_at", DateTimeOffset.Now.AddSeconds(Integer.Parse(arg.ProtocolMessage.ExpiresIn)).ToString()))
			'' add some other app specific claim
			'nid.AddClaim(New Claim("app_specific", "some data"))
			nid.AddClaim(New Claim(ClaimTypes.Role, "group1"))
			arg.AuthenticationTicket = New AuthenticationTicket(nid, arg.AuthenticationTicket.Properties)
			arg.AuthenticationTicket.Properties.RedirectUri = HttpContext.Current.Session("PageRedirect").ToString() 
		End Function
	End Class
