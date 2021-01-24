    public static T[] FastRead<T>(FileStream fs, int count) where T: struct
    {
        int sizeOfT = Marshal.SizeOf(typeof(T));
        long bytesRemaining  = fs.Length - fs.Position;
        long wantedBytes     = count * sizeOfT;
        long bytesAvailable  = Math.Min(bytesRemaining, wantedBytes);
        long availableValues = bytesAvailable / sizeOfT;
        long bytesToRead     = (availableValues * sizeOfT);
        if ((bytesRemaining < wantedBytes) && ((bytesRemaining - bytesToRead) > 0))
        {
            Debug.WriteLine("Requested data exceeds available data and partial data remains in the file.");
        }
        T[] result = new T[availableValues];
        GCHandle gcHandle = GCHandle.Alloc(result, GCHandleType.Pinned);
        try
        {
            uint bytesRead;
            if (!ReadFile(fs.SafeFileHandle, gcHandle.AddrOfPinnedObject(), (uint)bytesToRead, out bytesRead, IntPtr.Zero))
            {
                throw new IOException("Unable to read file.", new Win32Exception(Marshal.GetLastWin32Error()));
            }
            Debug.Assert(bytesRead == bytesToRead);
        }
        finally
        {
            gcHandle.Free();
        }
        GC.KeepAlive(fs);
        return result;
    }
    
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Interoperability", "CA1415:DeclarePInvokesCorrectly")]
    [DllImport("kernel32.dll", SetLastError=true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    
    private static extern bool ReadFile
    (
        SafeFileHandle       hFile,
        IntPtr               lpBuffer,
        uint                 nNumberOfBytesToRead,
        out uint             lpNumberOfBytesRead,
        IntPtr               lpOverlapped
    );
