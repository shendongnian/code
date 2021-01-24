    var results = grouped.Select(c => new {
	     c.FirstOrDefault()?.RatecardId,
	     c.FirstOrDefault()?.RatecardName,
	     c.FirstOrDefault()?.RatecardDescription,
	     c.FirstOrDefault()?.IsActive,
	     c.FirstOrDefault()?.IsPrivate,
	     c.FirstOrDefault()?.IsLocal,
	     c.FirstOrDefault()?.IsNetwork,
	     MDMChannelCallLetters = string.Join(", ", c.Select(x => x.MDMChannelCallLetters).ToList()),
	     UserName = string.Join(", ", c.Select(x => x.UserName).ToList())
    });
