     [ScriptableMember]
            public void LoggedIn(string uri) //string sessionKey, string sessionSecret, int expires, string userId, string allowedPermissions)
            {
                FacebookAuthenticationResult authResult;
                if (FacebookAuthenticationResult.TryParse(uri, out authResult))
                {
                    fbApp.Session = authResult.ToSession();
                    loginSucceeded();
                }
                else
                {
                    failedLogin();
                }
            }
