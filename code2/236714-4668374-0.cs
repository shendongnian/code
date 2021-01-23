    private static readonly ReadOnlyCollection<string> _metrics =
        new ReadOnlyCollection<string>(new[]
            {
                SourceFile.LOC,
                SourceFile.MCCABE,
                SourceFile.NOM,
                SourceFile.NOA,
                SourceFile.FANOUT,
                SourceFile.FANIN,
                SourceFile.NOPAR,
                SourceFile.NDC,
                SourceFile.CALLS
            });
    public static ReadOnlyCollection<string> Metrics
    {
        get { return _metrics; }
    }
