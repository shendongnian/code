    /// <summary>
        /// Client auth information, loaded from a Google user credential json file.
        /// Set the TEST_CLIENT_SECRET_FILENAME environment variable to point to the credential file.
        /// </summary>
        public class ClientInfo
        {
            public static ClientInfo Load()
            {
                const string ClientSecretFilenameVariable = "TEST_CLIENT_SECRET_FILENAME";
                string clientSecretFilename = Environment.GetEnvironmentVariable(ClientSecretFilenameVariable);
                if (string.IsNullOrEmpty(clientSecretFilename))
                {
                    throw new InvalidOperationException($"Please set the {ClientSecretFilenameVariable} environment variable before running tests.");
                }
                var secrets = JObject.Parse(Encoding.UTF8.GetString(File.ReadAllBytes(clientSecretFilename)))["web"];
                var projectId = secrets["project_id"].Value<string>();
                var clientId = secrets["client_id"].Value<string>();
                var clientSecret = secrets["client_secret"].Value<string>();
                return new ClientInfo(projectId, clientId, clientSecret);
            }
    
            private ClientInfo()
            {
                Load();
            }
    
    
            private ClientInfo(string projectId, string clientId, string clientSecret)
            {
                ProjectId = projectId;
                ClientId = clientId;
                ClientSecret = clientSecret;
            }
    
            public string ProjectId { get; }
            public string ClientId { get; }
            public string ClientSecret { get; }
        }
