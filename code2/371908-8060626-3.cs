    using (var transaction = sessionA.BeginTransaction())
    {
        var water = sessionA.Get<BodyOfWater>(1);
        water.Freeze();
        sessionA.Update(water);
        // Same point in time as the line indicated below...
        transaction.Commit();
    }
