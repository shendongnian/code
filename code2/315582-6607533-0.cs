    try {
        // something that uses AppDirectory, causing the error
    } catch (TypeInitializationException ex) {
        Trace.WriteLine(ex.InnerException);
        throw;
    }
