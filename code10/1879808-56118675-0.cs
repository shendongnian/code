    var q = (
         from sus in systemUserSessionManager.Get()
         join su in systemUserManager.Get() on sus.SystemUserId equals su.Id
         join p in personManager.Get() on su.PersonId equals p.Id
         select new { sus = sus, su = su, p = p})
         .Where(x => x.sus.EndTimeStamp >= oneDayAgo)
         .Select(x => new {
             Name = x.p.FirstName + " " + x.p.LastName,
             Email = x.su.Email,
             LastLogIn = x.sus.StartTimeStamp,
             LastSessionDurationInMinutes = 
                 DbFunctions.DiffMinutes(x.sus.StartTimeStamp, x.sus.EndTimeStamp),
             LastActive = x.sus.EndTimeStamp
         }).ToList();
