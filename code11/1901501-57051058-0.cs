    VssClientCredentials credntials = new VssClientCredentials();
    using (VssConnection connection = new VssConnection(this.CollectionUri, credentials)) 
    {
        WorkItemTrackingHttpClient witClient = connection.GetClient<WorkItemTrackingHttpClient>();
        var workItemTypes = witClient.GetWorkItemTypesAsync(ProjectName).SyncResult();
    }
