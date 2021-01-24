    var properties = _context.Properties.Select(p => new Property {
        Name = p.Name,
        Values = p.Values.Distinct()
    })
    .AsEnumerable()
    .Distinct(new PropertyNameComparer());
