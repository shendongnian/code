        var trios = modifications.Select(m => new { Modification = m, // select the modification obj itself
           FieldHistory = _applicationDbContext.FieldHistories.FirstOrDefault(fh =>
               fh.ModificationId == m.ModificationId && // I am assuming this is required
               fh.PropValId == (new List<string> {"Creating", "Created"}.Contains(m.ModificationStatus) ? 1 : 2)),
           Event = _applicationDbContext.Events.FirstOrDefault(e => e.EventId == m.EventId)
        }).ToList();
