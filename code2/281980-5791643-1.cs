    public bool SomeFunction(IntPtr windowHandle)
    {
        // Implementation here.
        // If you need the value of the pointer in the implementation,
        // you can use:
        // long actualValue = windowHandle.ToInt64();
    }
    
    long actualHandle = 1234;
    IntPtr handlePtr = new IntPtr(actualHandle);
    bool returnValue = SomeFunction(windowHandle);
