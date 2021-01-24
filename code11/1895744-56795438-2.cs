 C#
var list = new List<Tuple<object, int, int>> // item2 - UserId, item3 - InviterId
		{
			new Tuple<object, int, int>(new { Name = "Ivan" }, 1, 12),
			new Tuple<object, int, int>(new { Name = "George" }, 2, 3),
			new Tuple<object, int, int>(new { Name = "Phil" }, 3, 12),
			new Tuple<object, int, int>(new { Name = "John" }, 4, 3),
			new Tuple<object, int, int>(new { Name = "Giggs" }, 5, 1),
			new Tuple<object, int, int>(new { Name = "Higgins" }, 6, 1)
		};
		
		var grouped = list.ToLookup(t => t.Item2);
		
		var withInviter = grouped.Select(grp => Tuple.Create(list[grp.Key], grp));
		
		var sorted = withInviter.OrderBy(t => t.Item1.Item2);
Edit: I'm sorry, but as I read your example again I see I misunderstood what results you are looking for. I seems that users can be divided into invited and not invited? I will update my answer as it's not correct.
Edit 2: This one should work:
C#
    struct InviterAndInvited {
		public Tuple<object, int, int> Inviter;
		public IEnumerable<Tuple<object, int, int>> Invited;
	}
	
	public static void Main(string[] args)
	{
		var list = new List<Tuple<object, int, int>> // item2 - UserId, item3 - InviterId
		{
			new Tuple<object, int, int>(new { Name = "Ivan" }, 1, 12),
			new Tuple<object, int, int>(new { Name = "George" }, 2, 3),
			new Tuple<object, int, int>(new { Name = "Phil" }, 3, 12),
			new Tuple<object, int, int>(new { Name = "John" }, 4, 3),
			new Tuple<object, int, int>(new { Name = "Giggs" }, 5, 1),
			new Tuple<object, int, int>(new { Name = "Higgins" }, 6, 1)
		};
		
		var byInviter = list.ToLookup(u => u.Item3);
		
		var inviterInveted = list
			.Where(user => byInviter.Contains(user.Item2))
			.Select(user => new InviterAndInvited() {
				Inviter = user,
				Invited = GetOrDefault(byInviter, user.Item2)
			} );
		
		foreach (var grp in inviterInveted) // Print results
		{
			Console.WriteLine(grp.Inviter.Item1);
			foreach (var user in grp.Invited) {
				Console.WriteLine("\t" + user.Item1);
			}
		}
	}
