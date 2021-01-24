     vss = new VssBasicCredential(string.Empty, PAT);
     VssConnection connection = new VssConnection(tfsURI, vss);
     witClient = connection.GetClient<WorkItemTrackingHttpClient>();
    
     workItemClient = new WorkItemClient(witClient);
