    // Some APIs, like Storage, accept a credential in their Create()
    // method.
    public object AuthExplicit(string projectId, string jsonPath)
    {
        // Explicitly use service account credentials by specifying
        // the private key file.
        var credential = GoogleCredential.FromFile(jsonPath);
        var storage = StorageClient.Create(credential);
        // Make an authenticated API request.
        var buckets = storage.ListBuckets(projectId);
        foreach (var bucket in buckets)
        {
            Console.WriteLine(bucket.Name);
        }
        return null;
    }
    // Other APIs, like Language, accept a channel in their Create()
    // method.
    public object AuthExplicit(string projectId, string jsonPath)
    {
        var credential = GoogleCredential.FromFile(jsonPath)
            .CreateScoped(LanguageServiceClient.DefaultScopes);
        var channel = new Grpc.Core.Channel(
            LanguageServiceClient.DefaultEndpoint.ToString(),
            credential.ToChannelCredentials());
        var client = LanguageServiceClient.Create(channel);
        AnalyzeSentiment(client);
        return 0;
    }
