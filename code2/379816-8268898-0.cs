    [DllImport("MagicLib.DLL", CallingConvention = CallingConvention.Cdecl)]
    public static extern byte* bufferOperations(byte* incoming, int size);
    public void TestMethod()
    {
        var incoming = new byte[100];
        fixed (byte* inBuf = incoming)
        {
            byte* outBuf = bufferOperations(inBuf, incoming.Length);
            // Assume, that the same buffer is returned, only with data changed.
            // Or by any other means, get the real lenght of output buffer (e.g. from library docs, etc).
            for (int i = 0; i < incoming.Length; i++)
                incoming[i] = outBuf[i];
        }
    }
