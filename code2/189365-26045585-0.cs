    System.Runtime.InteropServices.ComTypes.IStream stream;
        byte[] fileData = System.IO.File.ReadAllBytes(filename);
        System.IntPtr hGlobal = System.Runtime.InteropServices.Marshal.AllocHGlobal(fileData.Length);
        System.Runtime.InteropServices.Marshal.Copy(fileData, 0, hGlobal, fileData.Length);
        NativeMethods.CreateStreamOnHGlobal(hGlobal, true, out stream);
        //[DllImport("ole32.dll")]
        //internal static extern int CreateStreamOnHGlobal(IntPtr hGlobal, bool fDeleteOnRelease, out IStream ppstm);
