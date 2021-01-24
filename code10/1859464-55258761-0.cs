    var collectionUri = $"http://{myserver}:808/tfs/{CollectionName}"
    VssConnection connection = new VssConnection(new Uri(collectionUri), vssCredentials);
    var workItemTrackingclient = connection.GetClient<WorkItemTrackingHttpClient>();
    WorkItemTrackingHttpClientBase client = connection.GetClient<WorkItemTrackingHttpClient>();
    var revs = client.GetRevisionsAsync($"{projectName}", workitemId).Result;
