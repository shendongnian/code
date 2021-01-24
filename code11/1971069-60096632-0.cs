    VssConnection testConnection = new VssConnection(new Uri("azure-devops-uri"), new Microsoft.VisualStudio.Services.Common.VssCredentials());
    var workItemClient = testConnection.GetClient<WorkItemTrackingHttpClient>();
    var gitClient = testConnection.GetClient<GitHttpClient>();
    string projectId = "cf456145-abgd-ffs23-be61-0fca39681234";
    string repositoryId = "d6856145-abgd-42a3-be61-0fca3968c555";
    var branchUri = string.Format
    (
        "vstfs:///Git/Ref/{0}%2f{1}%2f{2}",
        projectId,
        repositoryId,
        "GBmaster"
    );
    var json = new JsonPatchDocument();
    json.Add(
    new JsonPatchOperation()
    {
         Operation = Operation.Add,
         Path = "/relations/-",
         Value = new
         {
                rel = "ArtifactLink",
                url = branchUri,
                attributes = new
                {
                    name = "Branch",
                    comment = "Comment"
                }
         }
    });
    try
    {
         int workItemToUpdate = 142144;
         var update = workItemClient.UpdateWorkItemAsync(json, workItemToUpdate).Result;
    }
    catch (Exception e)
    {
         var error = e.Message;
    }
