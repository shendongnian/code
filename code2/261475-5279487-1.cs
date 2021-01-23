    using (var context = new Context())
    {
        foreach (var tag in TagsFromView)
        {
            context.Attach(tag);
        }
    
        // Now you load Event
        var e = context.Events.Where(e => e.Id == someId);
        foreach(var tag in TagsFromView)
        {
            // First access will trigger lazy loading but already
            // attached instances of tags are used
            e.Tags.Add(tag);
        }
        // Now you must delete all tags present in e.Tags and not
        // present in TagsFromView
    
        context.SaveChanges();
    }
