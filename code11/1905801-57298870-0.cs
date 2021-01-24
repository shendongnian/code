        public IDbConnection MyConnectionFactory()
        {
            ClientCredential clientCredential = new ClientCredential(ClientId,ClientSecret);
            AuthenticationContext authenticationContext = new AuthenticationContext(AuthorityUrl);
            AuthenticationResult authenticationResult = authenticationContext.AcquireTokenAsync(TargetUrl, clientCredential).Result;
            SqlConnection MyDataConnection = new SqlConnection(ConnectionString);
            MyDataConnection.AccessToken = authenticationResult.AccessToken;
            return MyDataConnection;
        }
