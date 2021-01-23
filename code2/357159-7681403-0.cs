    var mostPopularTopic = entityContainer.Topics
        .OrderByDescending(t => t.Replies.Count())
        .FirstOrDefault();
    if(mostPopularTopic != null) // If there were any topics...
    {
        // ...
    }
