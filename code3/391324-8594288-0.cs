    var query = from p in context.Participant
                join a in context.Assignment on p.UniqueId equals a.UniqueId into ag
                select new
                {
                  p.UniqueId,
                  p.CAI,
                  p.HRGuid,
                  p.FullName,
                  p.Email,
                  Assignment = ag.OrderByDescending(x => x.AssignmentNumber).FirstOrDefault()
                }
