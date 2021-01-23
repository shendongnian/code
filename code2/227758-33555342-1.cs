    const int AverageFrameSizeInMegabytes = 10; // 10MB
    
    /// <summary>
    /// Tries to create a MemoryFailPoint instance for enough megabytes to
    /// hold as many images as specified by <paramref name="numberOfImages"/>.
    /// </summary>
    /// <returns>
    /// A MemoryFailPoint instance if the requested amount of memory was
    /// available (at the time of this call), otherwise null.
    /// </returns>
    MemoryFailPoint GetMemoryFailPointFor(int numberOfImages)
    {
        MemoryFailPoint memoryReservation = null;
        try
        {
            memoryReservation =
                new MemoryFailPoint(AverageFrameSizeInMegabytes * numberOfImages);
        }
        catch (InsufficientMemoryException ex)
        {
            return null;
        }
        return memoryReservation;
    }
