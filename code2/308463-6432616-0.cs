            TeamFoundationServer tfs = TeamFoundationServerFactory.GetServer("http://WhateverServerUrl");
            IBuildServer buildServer = (IBuildServer)tfs.GetService(typeof(IBuildServer));
            VersionControlServer VsServer = (VersionControlServer)tfs.GetService(typeof(VersionControlServer));
            IBuildDetail build = buildServer.GetAllBuildDetails(new Uri("http://WhateverBuildUrl"));
            List<IChangesetSummary> associatedChangesets = InformationNodeConverters.GetAssociatedChangesets(build);
            foreach (IChangesetSummary changeSetData in associatedChangesets)
            {
                Changeset changeSet = VsServer.GetChangeset(changeSetData.ChangesetId);
                foreach (Change change in changeSet.Changes)
                {
                    bool a = change.Item.IsContentDestroyed;
                    long b = change.Item.ContentLength;
                }
            } 
