    var results = grouped.Select(c => new {
	     c.Key?.RatecardId,
	     c.Key?.RatecardName,
	     c.Key?.RatecardDescription,
	     c.Key?.IsActive,
	     c.Key?.IsPrivate,
	     c.Key?.IsLocal,
	     c.Key?.IsNetwork,
	     MDMChannelCallLetters = string.Join(", ", c.Select(x => x.MDMChannelCallLetters)),
	     UserName = string.Join(", ", c.Select(x => x.UserName))
    });
