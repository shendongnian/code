    try
    {
        //Something that could give MeteoriteHitDatacenterException
    }
    catch (MeteoriteHitDatacenterException ex)
    {
        //Please log when you're just catching something. Especially if the catch statement has side effects. Trust me.
        ErrorLog.Log(ex, "Just logging so that I have something to check later on if this happens.")
        
    }
