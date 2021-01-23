    try
    {
        engine.Start();
    }
    catch (SpecificException se)
    {
        // Do stuff with specific exception
    }
    catch (Exception ex)
    {
        // Show the user something unexpected happened 
    }
