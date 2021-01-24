    public async Task AddToDatabase(Form form)
    {
        Roadmaps roadmap = new Roadmaps {
            RoadmapTitle = form.title, 
            RoadmapSummary = form.summary, 
            RoadmapBody = form.body 
        };
        var tags = new Tags[form.tags.Length];
        for(int i = 0; i < tags.Length; i++)
        {
            tags[i] = new Tags();
            tags[i].TagId = form.tags[i];
        }
        var roadmapTags = new RoadmapTags[form.tags.Length];
        for(int i = 0; i < tags.Length; i++)
        {
            roadmapTags[i] = new RoadmapTags{Roadmap = roadmap, Tag = tags[i]};
        }
        _dbContext.AddRange(roadmapTags);
        _dbContext.SaveChangesAsync();
    }
