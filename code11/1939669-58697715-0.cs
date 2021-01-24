    _context.Events
    .Inlcude(e=>e.Markets)
    .Include(e=>e.Markets.Select(I=>I.Type))
    .Where(e=>e.DateTime>= startDate && e.DateTime<endDate)
    .OrderBy(e.DateTime)
    .OrderByDescending(e.LastUpdateDateTime )
    .ToList();
