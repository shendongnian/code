    internal static GatewayDbContext AddOrUpdateSeedData(this GatewayDbContext dbContext)
            {
                var defaultBand = dbContext.Bands
                    .FirstOrDefault(c => c.Id == Guid.Parse("e96bf6d6-3c62-41a9-8ecf-1bd23af931c9"));
    
                if (defaultBand == null)
                {
                    defaultBand = new Band { ... };
                    dbContext.Add(defaultBand);
                }
                return dbContext;
            }
