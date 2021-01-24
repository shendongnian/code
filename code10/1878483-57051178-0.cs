    queryEvents = context.Events.Where(s => s.IsActive == (byte?)RecordTypeEnum.Active)
                        .Include(s => s.EventOwner).Include(x => x.EventTickets)
                        .Where(g => g.IsActive == (byte)RecordTypeEnum.Active && g.EventOwner.IsActive == true)
                        .OrderByDescending(h => h.EventOwnerId).ThenBy(j => j.Title);
                    queryEvents = queryEvents.Select(o =>
                    {
                        o.EventTickets = o.EventTickets.Where(f => f.AvailableInventory > 0 && f.Amount != zero ).ToList();
                        return o;
                    }).ToList();
