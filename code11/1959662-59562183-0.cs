    int[] assetValues = client.ReadHoldingRegisters(startAddress, quantity);
    // for every assetValue create an Asset with Value equal to assetValue
    // and a foreign key equal to startAddress:
    var assetsToAdd = assetValues
        .Select(assetValue => new Asset()
        {
            Value = assetValue,
            SensorId = startAddress,
        });
    using (var dbContext = new MyDbContext(...))
    {
        // Add the Assets in one call to DbSet.AddRange(IEnumerable)
        dbContext.Assets.AddRange(assetsToAdd);
        // and save the changes:
        dbContext.SaveChanges();
    }
