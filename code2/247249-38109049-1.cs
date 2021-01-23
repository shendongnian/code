        XxxSoapClient xxxClient = new XxxSoapClient();
        ApplyCredentials(userName, password, xxxClient.ClientCredentials);
        private static void ApplyCredentials(string userName, string password, ClientCredentials clientCredentials)
        {
            clientCredentials.UserName.UserName = userName;
            clientCredentials.UserName.Password = password;
            clientCredentials.Windows.ClientCredential.UserName = userName;
            clientCredentials.Windows.ClientCredential.Password = password;
            clientCredentials.Windows.AllowNtlm = true;
            clientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
        }  
