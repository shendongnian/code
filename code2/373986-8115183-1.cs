    public unsafe void YourMethod(double d)
    {
        fixed (byte* b = BitConverter.GetBytes(d))
        {
            // Do stuff...
        }
    }
