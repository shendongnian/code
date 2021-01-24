    foreach (var g in tickets.GroupBy(x => x.TicketNumber))
    {
        var unique = !g.Skip(1).Any();
    	foreach (var ticket in g)
    	{
    		ticket.IsUnique = unique;
    	}
    }
