    char[] converter = Salt.ToCharArray();
    byte[] salt = new byte[converter.Length];
    
    fixed(char* pBytes = &converter[0])
    {
        fixed(byte* pSalt = &salt[0])
        {
            MoveMemory( pSalt, pBytes, converter.Length);
        }
    }
    
    
    [DllImport("Kernel32.dll", EntryPoint="RtlMoveMemory", SetLastError=false)]
    static extern void MoveMemory(IntPtr dest, IntPtr src, int size);
