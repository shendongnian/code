    IntPtr ptr = ... ; 
    int ptrLength = ...; 
    unsafe
    {
        Span<byte> byteArray = new Span<byte>(ptr.ToPointer(), ptrLength);
        for (int i = 0; i < byteArray.Length; i++ )
        {
            // Use it as normalarray array ;
            byteArray[i] = 6;
        }
        // You can always get a byte array . Caution, it allocates a new buffer
        byte[] realByteArray = byteArray.ToArray();
    }
