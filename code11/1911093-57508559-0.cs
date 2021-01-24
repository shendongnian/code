    var result = context.HotFixes.Select(hotfix => new
    {
        // Select only the hotfix properties you actually plan to use:
        Id = hotfix.Id,
        Date = hotfix.Date,
        ...
        AssociatedPRs = hotfix.AssociatedPRs.Select(accociatedPr => new
        {
            // again, select only the associatedPr properties that you plan to use
            Id = associatedPr.Id,
            Name = associatedPr.Name,
            ...
            // foreign key not needed, you already know the value
            // HotFixId = associatedPr.HotFixId
        })
        .ToList(),
        Details = hotfix.Details
            .Where(detail => detail.Available == 1)
            .Select(detail => new
            {
                Id = detail.Id,
                Description = detail.Description,
                ...
                // not needed, you know the value:
                // Available = detail.Available,
                // not needed, you know the value:
                // HotFixId = detail.HotFixId,
            })
            .ToList(),
    });
