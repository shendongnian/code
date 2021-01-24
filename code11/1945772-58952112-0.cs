    public async Task<int> GetReportCountXmonths(string name, int months)
    {
        var limit = new ObjectId(DateTime.Now.AddMonths(-(months)), 0, 1, 2);
        await GetCollection<Clients>()
            .Find(Builders<Clients>.Filter.Eq(d => d.name, name) 
                & Builders<Clients>.Filter.Gte(f => f.Id, limit)
            .CountDocumentsAsync();
    }
