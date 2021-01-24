                string AadInstance = "https://login.microsoftonline.com/{0}";
                string ResourceId = "https://database.windows.net/";
                AuthenticationContext authenticationContext = new AuthenticationContext(string.Format(AadInstance,"{tenantId}"));
                authenticationContext.ExtendedLifeTimeEnabled = true;
                ClientCredential clientCredential = new ClientCredential("{clientId}", "{secret}");
               AuthenticationResult authticationResult = authenticationContext.AcquireTokenAsync(ResourceId, clientCredential).Result;
                string ConnectionString =
    @"Data Source=n9lxnyuzhv.database.windows.net; Initial Catalog=testdb;";
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.AccessToken = authticationResult.AccessToken;
                conn.Open();
