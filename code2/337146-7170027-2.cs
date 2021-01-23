	private static Dictionary<
			ClientRating, Func<IEnumerable<Projects>, IEnumerable<Projects>>>
		_ratingSelectors = new Dictionary<
			ClientRating, Func<IEnumerable<Projects>, IEnumerable<Projects>>>()
		{
			{ ClientRating.HighGold, ps => ps.Where(p => p.Value > 200) },
			{ ClientRating.HighSilver, ps => ps.Where(p => p.Value > 125) },
			{ ClientRating.HighBronze, ps => ps.Where(p => p.Value > 60) },
			{ ClientRating.Gold, ps => ps.Where(p => p.Value > 175) },
			{ ClientRating.Silver, ps => ps.Where(p => p.Value > 100) },
			{ ClientRating.Bronze, ps => ps.Where(p => p.Value > 40) },
			{ ClientRating.LowGold, ps => ps.Where(p => p.Value > 150) },
			{ ClientRating.LowSilver, ps => ps.Where(p => p.Value > 80) },
			{ ClientRating.LowBronze, ps => ps.Where(p => p.Value > 20) },
		};
		
	public static List<Client> GetCustomersByRating(
		this IEnumerable<Client> clients,
		ClientRating rating)
	{
		return clients.GetCustomersByProjects(_ratingSelectors[rating]).ToList();
	}
