	private bool DescriptionValid(Membership membership, string identifier)
	{
		var query =
			from ms in new []
			{
				membership.premium.Select(m => new { m.Id, m.Remarks }),
				membership.club.Select(m => new { m.Id, m.Remarks }),
				membership.basic.Select(m => new { m.Id, m.Remarks }),
				membership.junior.Select(m => new { m.Id, m.Remarks }),
			}
			let ev = ms.Where(x => x.Id == identifier).SingleOrDefault()
			where ev != null && String.IsNullOrEmpty(ev.Remarks)
			select ev;
			
		return !query.Any();
	}
