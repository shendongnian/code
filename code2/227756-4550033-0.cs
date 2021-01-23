    const int AverageFrameSize = 10 * 1024 * 1024 // 10MB
    
    void Image_OnAcquired(...)
    {
        try
        {
            var memoryCheck = new MemoryFailPoint(AverageFrameSize * 3);
        }
        catch (InsufficientMemoryException ex)
        {
            _camera.StopAcquisition();
            StartWaitingForFreeMemory();
            return;
        }
        // if you get here, there's enough memory for at least a few
        // more frames
    }
 
