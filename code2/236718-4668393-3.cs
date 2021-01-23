    public static readonly IList<String> Metrics = new ReadOnlyCollection<string>
        (new List<String> { 
             SourceFile.LoC, SourceFile.McCabe, SourceFile.NoM,
             SourceFile.NoA, SourceFile.FanOut, SourceFile.FanIn, 
             SourceFile.Par, SourceFile.Ndc, SourceFile.Calls });
