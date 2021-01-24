    var image = context.Set<Image>()
                       .Include(i => i.Content)
                       .Include(i => i.Variations.Select(v => v.Content))
                       .Single(i => i.Id == id);
    foreach (var variation in image.Variations)
    {
        context.Set<Image>().Remove(variation);
    }
    context.Set<Image>().Remove(image);
