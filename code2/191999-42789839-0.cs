     public static void SetCredentials(string username, string password, string proxydomain)
        {
            Credential deleteCredentials = new Credential
            {
                Target = proxydomain
            };
            if (deleteCredentials.Exists())
                deleteCredentials.Delete();
         
            Credential proxyCredential = new Credential
            {
              
                Username = username,
                Password = password ,
                Target = proxydomain,
                Type = CredentialType.Generic,
                PersistanceType = PersistanceType.Enterprise
            };
            proxyCredential.Save();
        }
