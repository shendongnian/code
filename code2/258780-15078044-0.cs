    if (!MathKernel.IsConnected)
    {
        MathKernel.Connect();
    }
    
    if (MathKernel.IsComputing)
    {
        MathKernel.Abort();
    }
