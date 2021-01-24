public async Task<User> GetUser(int id)
{
    var user = await _context.Users
        .Include(a => a.Avatar)
        .Include(l => l.MyListings)
            .ThenInclude(p => p.Photos)
                .FirstOrDefaultAsync(u => u.Id == id);
        
    return user;
}
public async Task<Listing> GetListing(int id)
{
    var listing = await _context.Listings
        .Include(p => p.Photos)
        .FirstOrDefaultAsync(l => l.id == id);
    
    return listing;
}
