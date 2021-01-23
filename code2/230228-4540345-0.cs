    try
    {
    }
    // I don't care about exceptions.
    catch
    {
    }
    // Okay, well, except for system errors like out of memory or stack overflow.
    // I need to let those propagate.
    catch (SystemException exception)
    {
        // Unless this is an I/O exception, which I don't care about.
        if (exception is IOException)
        {
            // Ignore.
        }
        else
        {
            throw exception;
        }
    }
    // Or lock recursion exceptions, whatever those are... Probably shouldn't hide those.
    catch (LockRecursionException exception)
    {
        throw exception;
    }
    // Or, uh, what else? What am I missing?
    catch (???)
    {
    }
