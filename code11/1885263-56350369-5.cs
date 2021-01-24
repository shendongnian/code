        public async Task AddToDatabase(Form form)
        {
            var roadmap = new Roadmap {
                RoadmapTitle = form.title, 
                RoadmapSummary = form.summary, 
                RoadmapBody = form.body 
            };
            var roadmapTags = form.Tags
                .Select(tagId => new Tag        // First we take our form.tags and convert it to Tag objects
                {
                    TagId = tagId
                })
                .Select(tag => new RoadmapTags  // Then we take the result of the previous conversion and we 
                {                               // transform again to RoadmapTags, we even could do this in one pass
                    Roadmap = roadmap,          // but this way is more clear what the transformations are
                    Tag = tag
                })
                .ToList();
            
            _dbContext.AddRange(roadmapTags);
            await _dbContext.SaveChangesAsync();
        }
