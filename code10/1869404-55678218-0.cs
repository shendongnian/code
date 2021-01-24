    string projectName = "";
    int releaseId = 1;
    string collectionUri = "";
    VssCredentials creds = new VssClientCredentials();
    creds.Storage = new VssClientCredentialStorage();
    // Connect to Azure DevOps Services
    VssConnection connection = new VssConnection(new Uri(collectionUri), creds);
    ReleaseHttpClient releaseClient = connection.GetClient<ReleaseHttpClient>();
    ReleaseUpdateMetadata releaseUpdateMetadata = new ReleaseUpdateMetadata()
    {
        Comment = "Abandon the release",
        Status = ReleaseStatus.Abandoned
    };
    // Abandon a release
    WebApiRelease updatedRelease = releaseClient.UpdateReleaseResourceAsync(releaseUpdateMetadata, projectName, releaseId ).Result;
