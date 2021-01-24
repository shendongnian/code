    var mostUsedTags = images
        .SelectMany(i => i.Tags)           // Get all the ImageTags from all the images
        .GroupBy(t => t.Tag)               // Group them by the Tag property
        .OrderByDescending(g => g.Count()) // Order groups by their count (descending)
        .Take(10)                          // Take the top 10 results
        .Select(g => g.Count());           // Select the count associated with each tag
