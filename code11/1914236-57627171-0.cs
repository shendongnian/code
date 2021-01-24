            string collectionUri = "My_TFS_Server";
            string projectName = "My_Project_Name";
            int myWorkItemID = 7000;
            VssConnection connection = new VssConnection(new Uri(collectionUri), new VssCredentials());
            WorkItemTrackingHttpClient witClient = connection.GetClient<WorkItemTrackingHttpClient>();
            var wi =  witClient.GetWorkItemAsync(myWorkItemID ,null,null,WorkItemExpand.All).Result;
