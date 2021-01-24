    public DeleteFiveWhyMutator(MyContext dbContext, int dataStoryId) {
        this.dbContext = dbContext;
        this.dataStoryId = dataStoryId;
    }
    
    private FiveWhyAnalysis GetAnalysis() {
        var fwAnalysis = dbContext.DataStories
           .Where(ds => ds.Id = dataStoryId)
           .Select(ds => ds.FiveWhyAnalysis)
           .SingleOrDefault();
        return fwAnalysis;
    }
    
    public void Run() {
        var fwAnalysis = GetAnalysis();
        if (fwAnalysis == null)
            return;
    
        dbContext.FiveWhysAnalyses.Remove(fwAnalysis);
        dbContext.SaveChanges();
    }
