        protected bool IsProofKeyCodeForExchange
        {
            get
            {
                return
                    accessTokenUrl != null                    // AccessToken url is defined
                    &&
                    string.IsNullOrWhiteSpace(clientSecret)   // Client Secret is not defined
                    ;
            }
        }
