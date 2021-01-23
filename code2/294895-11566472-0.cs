    class AddResource
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool UpdateResource(IntPtr hUpdate, string lpType, string lpName, ushort wLanguage, IntPtr lpData, uint cbData);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr BeginUpdateResource(string pFileName,
           [MarshalAs(UnmanagedType.Bool)]bool bDeleteExistingResources);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool EndUpdateResource(IntPtr hUpdate, bool fDiscard);
    private static IntPtr ToPtr(object data)
    {
        GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
        IntPtr ptr;
        try
        {
            ptr = h.AddrOfPinnedObject();
        }
        finally
        {
            h.Free();
        }
        return ptr;
    }
    public static bool InjectResource(string filename, byte[] bytes, string resourceName)
    {
        try
        {
            IntPtr handle = BeginUpdateResource(filename, false);
            byte[] file1 = bytes;
            IntPtr fileptr = ToPtr(file1);
            bool res = UpdateResource(handle, resourceName,
                //"RT_RCDATA",
                "0", 0, fileptr, Convert.ToUInt32(file1.Length));
            EndUpdateResource(handle, false);
        }
        catch
        {
            return false;
        }
        return true;
    }
    public static void CopyStream(Stream input, Stream output,long sz)
    {
        // Insert null checking here for production
        byte[] buffer = new byte[sz];
        int bytesRead;
        while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
        {
            output.Write(buffer, 0, bytesRead);
        }
    }
