    using (var tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(uri))
    {
        tfs.EnsureAuthenticated();
        var vcs = tfs.GetService<VersionControlServer>();
        var item = vcs.GetItem("$/Proj/Main/", VersionSpec.Latest, DeletedState.Any, GetItemsOptions.IncludeBranchInfo);
    }
