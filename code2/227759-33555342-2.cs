    const int FrameSizeInMegabytes = 10; // 10MB (perhaps more is needed?)
    const int FrameSizeInBytes = FrameSizeInMegabytes << 20;
    // shifting by 20 is the same as multiplying with 1024 * 1024.
    
    bool TryCreateImageBuffer(int numberOfImages, out byte[,] imageBuffer)
    {
        // check that it is theoretically possible to allocate the array.
        if (numberOfImages  < 0 || numberOfImages > 0x7FFFFFC7)
            throw new ArgumentOutOfRangeException("numberOfImages",
                "Outside allowed range: 0 <= numberOfImages <= 0x7FFFFFC7");
        
        // check that we have enough memory to allocate the array.
        MemoryFailPoint memoryReservation = null;
        try
        {
            memoryReservation =
                new MemoryFailPoint(FrameSizeInMegabytes * numberOfImages);
        }
        catch (InsufficientMemoryException ex)
        {
            imageBuffer = null;
            return false;
        }
        // if you get here, there's likely to be enough memory
        // available to create the buffer. Normally we can't be
        // 100% sure because another thread might allocate memory
        // without first reserving it with MemoryFailPoint in
        // which case you have a race condition for the allocate.
        // Because of this the allocation should be done as soon
        // as possible - the longer we wait the higher the risk.
        imageBuffer = new byte[numberOfImages, FrameSizeInBytes];
        
        //Now that we have allocated the memory we can go ahead and call dispose
        memoryReservation.Dispose();
        
        return true;
    }
