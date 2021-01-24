c#
retQueryable = query.AsEnumerable().Select(k => new UserDTO()
				{
					Id = k.Id,
					TeamsDTOList = k.Teams.Select(t => new TeamDTO(){ Id = t.Id, Teamname = t.Teamname}).ToList()
				});
