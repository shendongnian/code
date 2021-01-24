    int[] assetValues = client.ReadHoldingRegisters(startAddress, quantity);
    using (var dbContext = new MyDbContext(...))
    {
        // Add one Sensor with all its Assets in one go
        dbContext.Sensors.Add(new Sensor()
        {
            // fill the Sensor properties that you know.
            // don't fill the Id
            ...
            Assets = assetValues
                     .Select(assetValue => new Asset()
                     {
                          Value = assetValue,
                          // no need to fill SensorId, Entity framework will do that for you
                          ... // if needed: fill other Asset properties
                     })
                     .ToList(),
        });
        dbContext.SaveChanges(); 
    }
