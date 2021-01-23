    using (var transaction = sessionB.BeginTransaction())
    {
        var water = sessionB.Get<BodyOfWater>(1);
        // ... Same point in time as the line indicated above.
        water.Boil();
        sessionB.Update(water);
        transaction.Commit();
    }
