	var results = query.GroupJoin(
		addresses,
		p => p.PersonID,
		a => a.PersonID,
		(p, a) =>
		new
		{
			p.PersonID,
			p.LastName,
			p.FirstName,
			p.MiddleName,
			p.SSN,
			p.BirthDate,
			p.DeathDate,
			AddressLine1 = a.Any()
				? (a.First().AddressLine1 ?? string.Empty)
				: null
		});
