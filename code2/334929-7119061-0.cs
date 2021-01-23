    var query = from c in context.Entities;
    if  (searchTermA != null) {
        query = query.Where(c => c.ColumnA == searchTermA);
    }
    // Rest of your conditions defined in the same way.
    var entities = query.Select(c => new { c.Property }).ToList();
