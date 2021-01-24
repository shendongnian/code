     public async Task<IEnumerable<P2PStats>> GetNetStatsLowestAndHighestDate(ushort id, ushort remoteId, DateTime start, DateTime end)
    {
        using (var ctx = new DataContext())
        {
            IQueryable<P2PStats> query = ctx.P2PStats
                 .Where(stat => stat.Date >= start && stat.Date <= end)
                 .Where(stat => stat.P2PStatsDetailed.Any(detail => detail.RemoteId == remoteId))
                 .DefaultIfEmpty(0)
                 .Max(s => s.Date)
             
                 .Select(stat => new P2PStats
                                            {
                                                Id = stat.Id,
                                                AxmCardId = stat.Id,
                                                Date = stat.Date,
                                                P2PStatsDetailed = stat.P2PStatsDetailed.Where(detail => detail.RemoteId == remoteId).ToList()
                                            });
            IQueryable<P2PStats> query2 = ctx.P2PStats
                 .Where(stat => stat.Date >= start && stat.Date <= end)
                 .Where(stat => stat.P2PStatsDetailed.Any(detail => 
            detail.RemoteId == 
            remoteId))
                 .DefaultIfEmpty(0)
                 .Min(s => s.Date)
             
                 .Select(stat => new P2PStats
                                            {
                                                Id = stat.Id,
                                                AxmCardId = stat.Id,
                                                Date = stat.Date,
                                                P2PStatsDetailed = 
            stat.P2PStatsDetailed.Where(detail => detail.RemoteId == remoteId).ToList()
                                            });
         
            var results = query1.Concat(query2);
                    
            return await results.ToListAsync();
            
        }
    }
