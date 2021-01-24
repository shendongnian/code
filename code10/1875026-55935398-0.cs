            public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
            {
    
                var Passwordbase64EncodedBytes = System.Convert.FromBase64String(context.Password);
                string password = System.Text.Encoding.UTF8.GetString(Passwordbase64EncodedBytes);
                       ........................
                }
