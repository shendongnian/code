        using Google.GData.Client;
        public bool ValidateGoogleAccount(string login, string password)
        {
            try
            {
                Service bloggerService = new Service("blogger", "App-Name");
                bloggerService.Credentials = new GDataCredentials(login, password);
                string token = bloggerService.QueryAuthenticationToken();
                if (token != null)
                    return true;
                else
                    return false;
            }
            catch (Google.GData.Client.InvalidCredentialsException)
            {
                return false;
            }
        }
