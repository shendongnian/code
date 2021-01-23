    using (var context = new Context())
    {
        // Just let assume these are your tags received from view model.
        var csharp = ...;
        var aspnet = ...;
        var ef4 = ...;
    
        // Now you load Event
        var e = context.Events.Where(e => e.Id == someId);
        // Ups first access to Tag collection triggers lazy loading which
        // is enabled by default so, all current tags are loaded
        e.Tags.Add(csharp);
        e.Tags.Add(aspnet);
        e.Tags.Add(ef4);
    
        // Now e.Tags.Count == 5 !!! Why?
        context.SaveChanges();
    }
