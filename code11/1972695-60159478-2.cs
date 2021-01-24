    using (var dbContext = new MyContext()) // Real code will DI the context.
    {
        Seed seed = new Seed(dbContext); 
        seed.Seed(); // remove async here as well to test.
    
        // Assert we have a FiveWhy...
        Assert.IsNotNull(seed.DataStory.FiveWhyAnalysis, "FiveWhyAnalysis was not seeded.");
        var mutator = new DeleteFiveWhyMutator(dbContext, seed.DataStory.Id);
        mutator.Run();
    
        // Assert the FiveWhy was removed...
        Assert.IsNull(seed.DataStory.FiveWhyAnalysis, "FiveWhyAnalysis was not removed.");
    }
