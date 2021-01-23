    public static class Superfast
    {
        [DllImport("msvcrt.dll",
                  EntryPoint = "memset",
                  CallingConvention = CallingConvention.Cdecl,
                  SetLastError = false)]
        private static extern IntPtr MemSet(IntPtr dest, int c, int count);
        //If you need super speed, calling out to M$ memset optimized method using P/invoke
        public static byte[] InitByteArray(byte fillWith, int size)
        {
            byte[] arrayBytes = new byte[size];
            GCHandle gch = GCHandle.Alloc(arrayBytes, GCHandleType.Pinned);
            MemSet(gch.AddrOfPinnedObject(), fillWith, arrayBytes.Length);
            return arrayBytes;
        }
    }
