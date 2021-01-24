	void Main()
	{
		var inner = new List<UserPage> {
			new UserPage { Id = 1, Name = "One" },
			new UserPage { Id = 2, Name = "Two" },
			new UserPage { Id = 3, Name = "Three" },
			new UserPage { Id = 4, Name = "Four" },
			new UserPage { Id = 5, Name = "Five" }};
	
		var outer = new List<UserPageSetting> {
			new UserPageSetting { UserId = 1, PageId = 1, Active = true, Published = true }};
		
		var joined = inner
			.GroupJoin(outer, i => i.Id, o => o.PageId, (i, o) => o
				   .Select(x => new { Inner = i, Outer = x })
				   .DefaultIfEmpty(new { Inner = i, Outer = new UserPageSetting {UserId = i.Id, PageId = i.Id, Active = false, Published = false } }))
			.SelectMany(x => x)
			//.Where(x => x.Outer == -1) -- include if you only want to see the join misses
			;
		
		foreach (var x in joined)
		{
			Console.WriteLine($"UserPage({x.Inner.Id}, {x.Inner.Name}) joined to UserPageSetting({x.Outer.UserId}, {x.Outer.Active})");
		}
	}
