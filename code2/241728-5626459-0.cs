    void GetPastTFSChangesByDate()
        {
            using (TfsTeamProjectCollection tfsServer = new TfsTeamProjectCollection(_tfsServerUri))
            {
                tfsServer.Authenticate();
                if (tfsServer != null)
                {
                    VersionControlServer vcServer = tfsServer.GetService(typeof (VersionControlServer)) as VersionControlServer;
                    if (vcServer != null)
                    {
                        var usersWorkspaces = vcServer.QueryWorkspaces(null, vcServer.AuthorizedUser, Environment.MachineName).ToList();
                        List<ChangedTFSItem> foundPastChanges = null;
                        if (_isSearchForPastChangesOn)
                        {
                            var allPastChangesets = vcServer.QueryHistory(@"C:\TFS",
                                                                          VersionSpec.Latest,
                                                                          0,
                                                                          RecursionType.Full,
                                                                          Environment.UserName,
                                                                          null,
                                                                          null,
                                                                          3000,
                                                                          true,
                                                                          false).Cast<Changeset>()
                                .Where(x => x.Committer.Contains(Environment.UserName));
                            _foundPastChanges = allPastChangesets
                                .SelectMany(x => x.Changes)
                                .Where(x => x.Item.CheckinDate.Date == _searchDate.Date) // Check-in date filter.
                                .DistinctBy(x => x.Item.ServerItem, x => x.Item.ServerItem.GetHashCode())
                                .Select(x => new ChangedTFSItem()
                                                 {
                                                     FileName = "Uknown",
                                                     LocalItem = "Uknown",
                                                     ServerItem = x.Item.ServerItem,
                                                     ChangeTypeName = "",
                                                     ChangeDate = x.Item.CheckinDate.ToString(),
                                                     Workspace = "Uknown"
                                                 }).ToList();
                            //Matching those foundPastChanges to the workspace corresponding file locations. 
                            if (usersWorkspaces.Any())
                            {
                                foreach (var item in foundPastChanges)
                                {
                                    usersWorkspaces.ForEach(ws =>
                                                                {
                                                                    item.LocalItem = ws.GetLocalItemForServerItem(item.ServerItem);
                                                                    item.Workspace = ws.Name;
                                                                });
                                    item.FileName = Path.GetFileName(item.ServerItem);
                                }
                            }
                        }
                    }
                }
            }
        }
