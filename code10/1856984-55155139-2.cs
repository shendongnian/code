    public IPagedList<Domain.Event> SearchEventsPublic(long[] eventCategoryTypeIds = null,
                                      long[] locationIds = null,
                                      DateTime? startDate = null,
                                      DateTime? endDate = null,
                                      int pageIndex = 0,
                                      int pageSize = int.MaxValue)
    {
        var query = _eventRepository.Table;
        // get event by filter
        if (eventCategoryTypeIds != null && eventCategoryTypeIds.Length > 0)
            query = query.Where(c => eventCategoryTypeIds.Contains(c.EventCategoryId));
        if (locationIds != null && locationIds.Length > 0)
            query = query.Where(c => locationIds.Contains(c.LocationId));
        var minDate = DateTime.Now;
        if (startDate.HasValue && startDate.Value > minDate)
        {
            minDate = startDate.Value;
        }
        query = query.Where(c => c.StartDateTime >= minDate ||
                            (c.PrePurchase && (c.ParentId == null || c.ParentId == 0)));
        if (endDate.HasValue)
        {
            var maxDate = endDate.Value.AddDays(1).AddTicks(-1);
            query = query.Where(c => c.StartDateTime <= maxDate ||
                            (c.PrePurchase && (c.ParentId == null || c.ParentId == 0)));
        }
        query = query.OrderBy(c => c.PrePurchase ? 0 : 1).ThenBy(c => c.StartDateTime);
    return new PagedList<Domain.Event>(query.AsQueryable(), pageIndex, pageSize);
    }
