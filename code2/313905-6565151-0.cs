    using (SvnClient client = new SvnClient())
    {
        client.Log(
            reposUri,
            new SvnLogArgs {Range = new SvnRevisionRange(9999, 9999)},
            (o, e) =>
                {
                    foreach (SvnChangeItem changeItem in e.ChangedPaths)
                    {
                        Console.WriteLine(
                            string.Format(
                                "{0} {1} {2} {3}",
                                changeItem.Action,
                                changeItem.Path,
                                changeItem.CopyFromRevision,
                                changeItem.CopyFromPath));
                    }
                });
    }
