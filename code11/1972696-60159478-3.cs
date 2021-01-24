    public void Run(DataStory dataStory) {
        if (dataStory == null)
            throw new ArgumentNullException("dataStory");
        if (dataStory.FiveWhyAnalysis == null)
            return;
    
        dbContext.FiveWhysAnalyses.Remove(dataStory.FiveWhyAnalysis);
        dbContext.SaveChanges();
    }
