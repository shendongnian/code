    using Microsoft.TeamFoundation.Core.WebApi;
    using Microsoft.VisualStudio.Services.Common;
    using Microsoft.VisualStudio.Services.WebApi;
    using System;
    using System.Collections.Generic;
    
    namespace Microsoft.TeamServices.Samples.Client.ProjectsAndTeams
    {
        [ClientSample(CoreConstants.AreaName, CoreConstants.ProjectCollectionsResource)]
        public class ProjectCollectionsSample : ClientSample
        {
    
            [ClientSampleMethod]
            public IEnumerable<TeamProjectCollectionReference> ListProjectCollections()
            {         
                VssConnection connection = Context.Connection;
                ProjectCollectionHttpClient projectCollectionClient = connection.GetClient<ProjectCollectionHttpClient>();
    
                IEnumerable<TeamProjectCollectionReference> projectCollections = projectCollectionClient.GetProjectCollections().Result;
    
                foreach(var collection in projectCollections)
                {
                    Console.WriteLine(collection.Name);
                }
    
                return projectCollections;
            }
    
        }
    }
