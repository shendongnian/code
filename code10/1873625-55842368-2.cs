      else if (string.Equals(loginInfo.Login.LoginProvider, "twitter", StringComparison.CurrentCultureIgnoreCase))
            {
                // Generate credentials that we want to use
                var identity = AuthenticationManager.GetExternalIdentity(DefaultAuthenticationTypes.ExternalCookie);
                var access_token = identity.FindFirstValue(LinqToTwitterAuthenticationProvider.AccessToken);
                var access_token_secret = identity.FindFirstValue(LinqToTwitterAuthenticationProvider.AccessTokenSecret);
                var creds = new TwitterCredentials(ConfigurationManager.AppSettings["TwitterConsumerKey"], ConfigurationManager.AppSettings["TwitterConsumerSecret"],access_token, access_token_secret);
                var authenticatedUser = Tweetinvi.User.GetAuthenticatedUser(creds);
                email = authenticatedUser.Email;
                firstName = authenticatedUser.Name.Substring(0, authenticatedUser.Name.IndexOf(' '));
                lastName = authenticatedUser.Name.Substring(authenticatedUser.Name.IndexOf(' ') + 1);
            }
