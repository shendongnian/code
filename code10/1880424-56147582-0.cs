    User.Groups = context.Groups.Where(g => g.Members.Any(m => m.UserId == x.Id)).Select(g => new GenericData
    {
    	Id = g.Id,
    	Tag = g.Tag,
    	Label = g.Name,
    	Flag = g.Flag
    }).ToList()
