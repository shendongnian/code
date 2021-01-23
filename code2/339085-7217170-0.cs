    void ChangeSerialNumber(char volume, uint newSerial)
    {
        var fsInfo = new[]
        {
            new { Name = "FAT32", NameOffs = 0x52, SerialOffs = 0x43 },
            new { Name = "FAT", NameOffs = 0x36, SerialOffs = 0x27 },
            new { Name = "NTFS", NameOffs = 0x03, SerialOffs = 0x48 }
        };
    
        using (var disk = new Disk(volume))
        {
            var sector = new byte[512];
            disk.ReadSector(0, sector);
    
            var fs = fsInfo.FirstOrDefault(
                    f => Strncmp(f.Name, sector, f.NameOffs)
                );
            if (fs == null) throw new NotSupportedException("This file system is not supported");
    
            var s = newSerial;
            for (int i = 0; i < 4; ++i, s >>= 8) sector[fs.SerialOffs + i] = (byte)(s & 0xFF);
    
            disk.WriteSector(0, sector);
        }
    }
    
    bool Strncmp(string str, byte[] data, int offset)
    {
        for(int i = 0; i < str.Length; ++i)
        {
            if (data[i + offset] != (byte)str[i]) return false;
        }
        return true;
    }
    
    class Disk : IDisposable
    {
        private SafeFileHandle handle;
    
        public Disk(char volume)
        {
            var ptr = CreateFile(
                String.Format("\\\\.\\{0}:", volume),
                FileAccess.ReadWrite,
                FileShare.ReadWrite,
                IntPtr.Zero,
                FileMode.Open,
                0,
                IntPtr.Zero
                );
    
            handle = new SafeFileHandle(ptr, true);
    
            if (handle.IsInvalid) Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
        }
    
        public void ReadSector(uint sector, byte[] buffer)
        {
            if (buffer == null) throw new ArgumentNullException("buffer");
            if (SetFilePointer(handle, sector, IntPtr.Zero, EMoveMethod.Begin) == INVALID_SET_FILE_POINTER) Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
    
            uint read;
            if (!ReadFile(handle, buffer, buffer.Length, out read, IntPtr.Zero)) Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            if (read != buffer.Length) throw new IOException();
        }
    
        public void WriteSector(uint sector, byte[] buffer)
        {
            if (buffer == null) throw new ArgumentNullException("buffer");
            if (SetFilePointer(handle, sector, IntPtr.Zero, EMoveMethod.Begin) == INVALID_SET_FILE_POINTER) Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
    
            uint written;
            if (!WriteFile(handle, buffer, buffer.Length, out written, IntPtr.Zero)) Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            if (written != buffer.Length) throw new IOException();
        }
    
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (handle != null) handle.Dispose();
            }
        }
    
        enum EMoveMethod : uint
        {
            Begin = 0,
            Current = 1,
            End = 2
        }
    
        const uint INVALID_SET_FILE_POINTER = 0xFFFFFFFF;
    
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr CreateFile(
            string fileName,
            [MarshalAs(UnmanagedType.U4)] FileAccess fileAccess,
            [MarshalAs(UnmanagedType.U4)] FileShare fileShare,
            IntPtr securityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
            int flags,
            IntPtr template);
    
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern uint SetFilePointer(
             [In] SafeFileHandle hFile, 
             [In] uint lDistanceToMove,
             [In] IntPtr lpDistanceToMoveHigh,
             [In] EMoveMethod dwMoveMethod);
    
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadFile(SafeFileHandle hFile, [Out] byte[] lpBuffer,
            int nNumberOfBytesToRead, out uint lpNumberOfBytesRead, IntPtr lpOverlapped);
    
        [DllImport("kernel32.dll")]
        static extern bool WriteFile(SafeFileHandle hFile, [In] byte[] lpBuffer,
            int nNumberOfBytesToWrite, out uint lpNumberOfBytesWritten,
            [In] IntPtr lpOverlapped);
    }
