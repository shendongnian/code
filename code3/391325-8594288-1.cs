    var query = (from p in context.Participant
                join a in context.Assignment on p.UniqueId equals a.UniqueId into ag
                select new
                {
                  Participant = p,
                  Assignment = ag.OrderByDescending(x => x.AssignmentNumber).FirstOrDefault()
                }).AsEnumerable()
                  .Select(x => new Participant(x.Participant )
                         {    
                            Assignments = new Assignment[] { x.Assignment }
                         };
