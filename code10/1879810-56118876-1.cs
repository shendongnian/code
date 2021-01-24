c#
var q = systemUserSessionManager.Get()
    .Where(sus => sus.EndTimeStamp >= oneDayAgo)
    .Join(systemUserManager.Get(), 
        sus => sus.SystemUserId, 
        su => su.Id, 
        (sus, su) => new { sus, su })
    .Join(personManager.Get(), 
        j => j.su.PersonId, 
        p => p.Id, 
        (j, p) => new { sus = j.sus, su = j.su, p })
    .Select(x => new
    {
        Name = p.FirstName + " " + p.LastName,
		Email = su.Email,
		LastLogIn = sus.StartTimeStamp,
		LastSessionDurationInMinutes = 
            DbFunctions.DiffMinutes(sus.StartTimeStamp, sus.EndTimeStamp),
		LastActive = sus.EndTimeStamp
    })
	.ToList();
