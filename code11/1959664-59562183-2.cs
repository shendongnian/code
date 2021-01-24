    using (var dbContext = new MyDbContext(...))
    {
        // Add one Sensor without Assets
        var addedSensor = dbContext.Sensors.Add(new Sensor()
        {
            // fill the Sensor properties that you know.
            // don't fill the Id, nor property Assets
            ...
        });
        // Add the Assets in one call to DbSet.AddRange(IEnumerable)
        dbContext.Assets.AddRange(assetValues.Select(assetValue => new Asset()
                         {
                             Value = assetValue,
                             Sensor = addedSensor,
                         }));
        dbContext.SaveChanges(); 
    }
