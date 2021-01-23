      // Replace with your setup
      var tfsServer = @"http://tfsserver:8080/tfs/SW";
      var serverPath = @"$/PCSW/ProjectX/Main";
      // Connect to server
      var tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(tfsServer));
      tfs.Connect(ConnectOptions.None);
      var vcs = tfs.GetService<VersionControlServer>();
      // Create versionspec's. Example start with changeset 529
      VersionSpec versionFrom = VersionSpec.ParseSingleSpec("C529", null);
      // If you want all changesets use this versionFrom:
      // VersionSpec versionFrom = null;
      VersionSpec versionTo = VersionSpec.Latest;
      // Get Changesets
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
