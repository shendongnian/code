    try
    {
        var seed = new Seed.CrSeedClient();
        string semilla = await seed.getSeedAsync();
    }
    catch(Exception e)
    {
        var details = e.InnerException;
    }
