    var query = context.UserRefernces
                       .Where(x => x.User_iod == iod);
    if (favorites != null) {
        query = query.Where(x => favorites.Contains((Guid)x.FavId));
    }
    // same for "histories" and "orders"
    
    var result = await query
               .AsNoTracking()
               .ToListAsync()
               .ConfigureAwait(false);
