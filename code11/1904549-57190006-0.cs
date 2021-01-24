      var TicketList =   Tickets
        .Join( Groups,
             ticket => ticket.GroupID,
             group => group.ID,
             (customer , group ) => new { Ticket = ticket, Group = group})
    .Where(x => x.Group.UserId == 4 && (x.Ticket.StatusId == 3 || x.Ticket.UserCreatedBy == 4) && x.Ticket.StatusId == 3)
             .Select(select => select.Ticket ).ToList();
        
