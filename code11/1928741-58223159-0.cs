    IQueryable<CustomerEvent> customerEvents = _customerEventRepository
                                                   .CustomerEvents
                                                   .Include(x => x.Customer);
    if (customerid.HasValue)
    {
        customerEvents = customerEvents.Where(x => x.Customer.CustomerId == customerid);
    }
    if (!string.IsNullOrEmpty(code))
    {
        customerEvents = customerEvents.Where(x => x.EventType == code); 
    }
    // other conditions
    ...
    // finally (this is when the query is actually executed)
    var onePageOfEvents = customerEvents
                             .OrderByDescending(x => x.CustomerEventId)
                             .ToPagedList(page, 15);
    return View(onePageOfEvents);
    
