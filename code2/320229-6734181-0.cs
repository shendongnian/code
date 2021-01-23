    class Index
    {
        public Dictionary<string, List<SourceFile>> FilesThatContainThisWord {get; set;}
        ...
    }
    
    
    class SourceFile
    {
        public string Path {get; set;}
        ...
    }
    
    
    // Code to look up a term
    var filesThatContainMonday = myIndex.FilesThatContainThisWord["Monday"];
