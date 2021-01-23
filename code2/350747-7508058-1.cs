    new RavenResearch.Task {
        TaskId = Guid.NewGuid(),
        CreatedDate = DateTime.Now,
        DynamicProperties = new Dictionary<string, object> {
            { "MatterNumber", 0 },
            { "CustomerNumber", "37" } 
        }
    }
