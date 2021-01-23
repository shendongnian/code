    namespace TFSChangelog
    {
      public class TFSChangelogGenerator
      {
        private const string workItemDoneText = "Done";
        
        /// <summary>
        /// This class describes a change by:
        /// Changeset details
        /// and
        /// WorkItem details
        /// </summary>
        public class ChangeInfo
        {
          #region Changeset details
    
          public DateTime ChangesetCreationDate { get; set; }
          public int ChangesetId { get; set; }
    
          #endregion
    
          #region WorkItem details
    
          public string WorkItemTitle { get; set; }
          public int WorkItemId { get; set; }
    
          #endregion
        }
    
        public static List<ChangeInfo> GetChangeinfo(string tfsServer, string serverPath, string from, string to)
        {
          // Connect to server
          var tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(tfsServer));
          tfs.Connect(ConnectOptions.None);
          var vcs = tfs.GetService<VersionControlServer>();
    
          // Create versionspec's
          VersionSpec versionFrom = null;
          if (!string.IsNullOrEmpty(from))
            versionFrom = VersionSpec.ParseSingleSpec(from, null);
          VersionSpec versionTo = VersionSpec.Latest;
          if (!string.IsNullOrEmpty(to))
            versionTo = VersionSpec.ParseSingleSpec(to, null);
    
          // Internally used dictionary
          var changes = new Dictionary<int, ChangeInfo>();
          
          // Find Changesets that are checked into the branch
          var directChangesets = vcs.QueryHistory(
            serverPath,
            VersionSpec.Latest,
            0,
            RecursionType.Full,
            null,
            versionFrom,
            versionTo,
            Int32.MaxValue,
            true,
            false
            ).Cast<Changeset>();
          foreach (var changeset in directChangesets)
          {
            foreach (var workItem in changeset.WorkItems.Where(workItem => workItem.State == workItemDoneText))
            {
              if (changes.ContainsKey(workItem.Id))
              {
                if (changeset.ChangesetId < changes[workItem.Id].ChangesetId) continue;
              }
              changes[workItem.Id] = new ChangeInfo { ChangesetId = changeset.ChangesetId, ChangesetCreationDate = changeset.CreationDate, WorkItemId = workItem.Id, WorkItemTitle = workItem.Title };
            }
          }
    
          // Find Changesets that are merged into the branch
          var items = vcs.GetItems(serverPath, RecursionType.Full);
          foreach (var item in items.Items)
          {
            var changesetMergeDetails = vcs.QueryMergesWithDetails(
              null,
              null,
              0,
              item.ServerItem,
              VersionSpec.Latest,
              0,
              versionFrom,
              versionTo,
              RecursionType.Full
            );
            foreach (var merge in changesetMergeDetails.Changesets)
            {
              foreach (var workItem in merge.WorkItems.Where(workItem => workItem.State == workItemDoneText))
              {
                if (changes.ContainsKey(workItem.Id))
                {
                  if (merge.ChangesetId < changes[workItem.Id].ChangesetId) continue;
                }
                changes[workItem.Id] = new ChangeInfo { ChangesetId = merge.ChangesetId, ChangesetCreationDate = merge.CreationDate, WorkItemId = workItem.Id, WorkItemTitle = workItem.Title };
              }
            }
          }
    
          // Return a list sorted by ChangesetId      
          return (from entry in changes orderby entry.Value.ChangesetId descending select entry.Value).ToList();
        }
      }
    }
