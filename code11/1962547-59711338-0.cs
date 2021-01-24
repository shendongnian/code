        // Do not change this id which fixed for azure devops.
        private const string VstsResourceId = "499b84ac-1321-427f-aa17-267ca6975798";
        public static void Main(string[] args)
        {
            var username = "{pass username here}"; 
            var password = "{pass password here}"; 
            var aadApplicationID = "{the application ID}"; 
            var adalCredential = new UserPasswordCredential(username, password);// make use of ADAL SDK
            var authenticationContext = new AuthenticationContext("https://login.microsoftonline.com/common");
            var result = authenticationContext.AcquireTokenAsync(VstsResourceId, aadApplicationID, adalCredential).Result;
            var token = new VssAadToken(result);
            var vstsCredential = new VssAadCredential(token);
            var connection = new VssConnection(new Uri("https://dev.azure.com/{org name}"), vstsCredential);
            var client = connection.GetClient<DelegatedAuthorizationHttpClient>();
            var pat = client.CreateSessionToken(
                displayName: "PAT Generate",
                tokenType: SessionTokenType.Compact,
                scope: "vso.work"
                ).Result;
           //print the token to verify the script
            Console.WriteLine(pat.Token);
        }
    }
