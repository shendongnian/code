    for(int attempts = 0; attempts < 5; attempts++)
    // if you really want to keep going until it works, use   for(;;)
    {
        try
        {
            DoWork();
            break;
        }
        catch { }
    }
