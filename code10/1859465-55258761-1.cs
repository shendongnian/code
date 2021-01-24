    var collectionUri = $"http://{myserver}:808/tfs/{CollectionName}"
    VssCredentials vssCredentials = new VssCredentials();
    VssConnection connection = new VssConnection(new Uri(collectionUri), vssCredentials);
    WorkItemTrackingHttpClientBase client = connection.GetClient<WorkItemTrackingHttpClient>();
    var revs = client.GetRevisionsAsync($"{projectName}", workitemId).Result;
