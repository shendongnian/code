    this.ObjectContext.Logs
            .Where(w => w.Message == "Created User" || 
                   w.Message == "Removed User" || 
                   w.Message == "Updated User")
            .GroupBy(w => w.Username)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .Take(5);
