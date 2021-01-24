    public void UpdateTickets(IList<Ticket> tickets)
    {
        var uniqueTickets = tickets.GroupBy (t => t.TicketNumber)
    		.Where (t => t.Count () == 1)
    		.SelectMany (t => t);
    		
    	foreach (var ticket in uniqueTickets)
    	{
    		ticket.IsUnique = true;
    	}
    }
