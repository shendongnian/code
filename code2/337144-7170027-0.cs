	public static class ClientEx
	{
		public static List<Client> GetCustomersByProjects(
			this IEnumerable<Client> clients,
			Func<IEnumerable<Projects>, IEnumerable<Projects>> selector)
		{
			var query =
				from c in clients
				let ps = selector(c.Projects).ToList()
				where ps.Any()
				select new Client()
				{
					Name = c.Name,
					Projects = ps,
				};
				
			return query.ToList();
		}
		
		public static List<Client> GetCustomersByProjectValuesGreaterThan(
			this IEnumerable<Client> clients, int value)
		{
			return clients.GetCustomersByProjects(ps => ps.Where(p => p.Value > value));
		}
		
		public static List<Client> GetHighGoldCustomers(
			this IEnumerable<Client> clients)
		{
			return clients.GetCustomersByProjectValuesGreaterThan(200);
		}
	}
