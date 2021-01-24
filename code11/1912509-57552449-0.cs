    worldEventContext
        .Include(PresentationContext)
        .Select(
            w => new
            {
                w.ID,
                w.Name,
                PresentationList = w.PresentationContext.Where(p => p.Country == "UK")
            })
