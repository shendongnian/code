        private static byte[] aditionalEntropy = { 1, 2, 3, 4, 5 };
        private static IAuthorizationState GetAuthorization(NativeApplicationClient arg)
        {
            // Get the auth URL:
            IAuthorizationState state = new AuthorizationState(new[] { PlusService.Scopes.PlusMe.GetStringValue() });
            state.Callback = new Uri(NativeApplicationClient.OutOfBandCallbackUrl);
       
            string refreshToken = LoadRefreshToken();
            if (!String.IsNullOrWhiteSpace(refreshToken))
            {
                state.RefreshToken = refreshToken;
                if (arg.RefreshToken(state))
                    return state;
            }
            Uri authUri = arg.RequestUserAuthorization(state);
            // Request authorization from the user (by opening a browser window):
            Process.Start(authUri.ToString());
            Console.Write("  Authorization Code: ");
            string authCode = Console.ReadLine();
            Console.WriteLine();
            // Retrieve the access token by using the authorization code:
            var result = arg.ProcessUserAuthorization(authCode, state);
            StoreRefreshToken(state);
            return result;
        }
        private static string LoadRefreshToken()
        {
            return Encoding.Unicode.GetString(ProtectedData.Unprotect(Convert.FromBase64String(Properties.Settings.Default.RefreshToken), aditionalEntropy, DataProtectionScope.CurrentUser));
        }
        private static void StoreRefreshToken(IAuthorizationState state)
        {
            Properties.Settings.Default.RefreshToken = Convert.ToBase64String(ProtectedData.Protect(Encoding.Unicode.GetBytes(state.RefreshToken), aditionalEntropy, DataProtectionScope.CurrentUser));
            Properties.Settings.Default.Save();
        }
