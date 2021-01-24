      queryEvents = context.Events.Where(s => s.IsActive == (byte?) RecordTypeEnum.Active)
                        .Include(s => s.EventOwner)
        .Select(e => new{
        e, 
        EventTicklets = e.EventTickets.Where(y => y.AvailableInventory >= 1 ).ToList()
    })
                        .Where(g => g.e.IsActive != null && g.e.EventOwner.IsActive == true)
