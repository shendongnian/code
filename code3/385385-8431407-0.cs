    using System;
    using System.Collections.Generic;
    using Microsoft.TeamFoundation.Build.Client;
    using Microsoft.TeamFoundation.Client;
    
    namespace GetChangesetsFromBuild
    {
        class Program
        {
            static void Main()
            {
                TfsTeamProjectCollection tpc = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri("http://TFSServer:8080/Name"));
                IBuildServer bs = (IBuildServer)tpc.GetService(typeof(IBuildServer));
    
                IBuildDetail build = bs.GetAllBuildDetails(new Uri("vstfs:///..."));
    
                List<IChangesetSummary> associatedChangesets = InformationNodeConverters.GetAssociatedChangesets(build);
    
                int idMax = associatedChangesets[0].ChangesetId; 
            }
        }
    }
