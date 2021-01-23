    bool keepTrying = false;
    int retryCount = 3;
    do
    {
        try
        {
            SomeOperation();
            keepTrying = false;
        }
        catch (SomeException)
        {
            if (retryCount > 0)
            {
                keepTrying = true;
                retryCount--;
            }
        }
    } while (keepTrying)
