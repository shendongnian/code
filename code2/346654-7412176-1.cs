    TryWithCleanUpOnException(foo, cleanUpResourceFoo);
    TryWithCleanUpOnException(bar, cleanUpResourceBar);
    ...
    private static void TryWithCleanUpOnException(Action action,
                                                  Action cleanUp)
    {
        bool success = false;
        try
        {
            action();
            success = true;
        }
        finally
        {
            if (!success)
            {
                cleanup();
            }
        }
    }
