    public IQueryable<Anomaly> GetAll()
    {    return _context.Anomalies
        .Include(a => a.Asset)
        .Include(a => a.Level);
    }
    public async Task<Anomaly> GetAnomaly(int anomalyId, User user)
    {
        var anomaly = await GetAll()
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == anomalyId);
        return anomaly;
    }
