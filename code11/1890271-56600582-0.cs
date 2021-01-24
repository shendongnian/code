    public async Task<List<RepairOrder>> GetAllRepairOrders()
    {
         return await db.RepairOrder
           .AsNoTracking()   // tracking is expensive, only do it whne needed
           .ToListAsync();   // or maybe ToArrayAsync
    }
