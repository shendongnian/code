    var tickets = await _context.Tickets
            .Include(c => c.Client)
            .Include(r => r.Region)
            .Include(rl => rl.RouteLink)
            .Include(e => e.Engineer)
            .Include(p => p.Priority)
            .Include(s => s.Statuses.).ThenInclude(s => s.Status)
            .Include(tcb => tcb.TicketCreatedBy)
            .Include(t => t.Team)
            .Select(x => new TicketDto
             {
                ...
                Statuses = x.Statuses.OrderByDescending(o => o.DateProperty).Take(1)
                ...
             })
            .ToListAsync();
