    var u = new Uri("collection url");
                string projectName = "project";
                VssCredentials c = new VssCredentials(new Microsoft.VisualStudio.Services.Common.WindowsCredential(new NetworkCredential("username", "password", "domain"))); 
                var connection = new VssConnection(u, c);
                var workitemClient = connection.GetClient<WorkItemTrackingHttpClient>();
               var query= workitemClient.GetQueryAsync(projectName, "Shared Queries/BugInUserStory").Result;
              var result=  workitemClient.QueryByIdAsync(query.Id).Result;
                var totalCounts = result.WorkItemRelations.Count(); //included User Story
