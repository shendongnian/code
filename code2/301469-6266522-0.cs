    IQueryable<cerberus_Ticket> matches = db.cerberus_Tickets;
    
      
     if (this.AgentIdField.Text.Trim().Length > 0)
     {
         matches = matches.Where(a => a.AgentId == criteria.AgentId);
     }
    
      if (this.TicketIdField.Text.Trim().Length > 0)
     {
         matches = matches.Where(a => a.TicketId.Contains(criteria.TicketId));
     } 
    
    var output = matches.ToList();
