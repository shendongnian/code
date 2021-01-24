    public IQueryable<Anomaly> GetAll()
    {    return _context.Anomalies.AsNoTracking().Include(a => a.Asset).Include(a => a.Level)
    }
    public async Task<Anomaly> GetAnomaly(int anomalyId, User user)
    {
        var anomaly = await GetAll()
            .FirstOrDefaultAsync(a => a.Id == anomalyId);
        return anomaly;
    }
