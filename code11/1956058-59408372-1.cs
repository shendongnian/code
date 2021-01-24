	public List<Staff[]> CreateTeams(int membersPerTeam)
	{
		IList<Staff> allUsers = GetStaff();
		int teams = allUsers.Count() / membersPerTeam;
		return
			allUsers
				.Select((x, n) => new { x, n })
				.GroupBy(z => z.n % teams)
				.Select(zs => zs.Select(z => z.x).ToArray())
				.ToList();
	}
