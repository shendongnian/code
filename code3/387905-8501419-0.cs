    using System;
    using System.Linq;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.VersionControl.Client;
    
    namespace GetFilesOfLatestChangesets
    {
        class Program
        {
            static void Main()
            {
                TfsTeamProjectCollection teamProjectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri("TFS_URI"));
                var vcS = teamProjectCollection.GetService(typeof (VersionControlServer)) as VersionControlServer;
                var changesets =
                    vcS.QueryHistory("$/", VersionSpec.Latest, 0, RecursionType.Full, null, null, null, 10, true, false).
                        Cast<Changeset>();
                foreach (var changeset in changesets)
                {
                    Console.WriteLine("Changes for "+changeset.ChangesetId);
                    foreach (var change in changeset.Changes)
                    {
                       Console.WriteLine(change.Item.ServerItem); 
                    }
                }  
            }
        }
    }
