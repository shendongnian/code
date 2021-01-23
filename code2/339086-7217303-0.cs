    static uint GenericRead = 0x80000000;
    static uint GenericWrite = 0x40000000;                       
    static uint OpenExisting = 3;
    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern SafeFileHandle CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr SecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);
    
    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    static extern bool GetDiskFreeSpace(string lpRootPathName, out uint lpSectorsPerCluster, out uint lpBytesPerSector, out uint lpNumberOfFreeClusters, out uint lpTotalNumberOfClusters);
    static void ReadAndSetSerialNumber()
    {
      const string driveLetter = "e:"; // Drive with FAT32 file system.
      uint sectorsPerCluster;
      uint bytesPerSector;
      uint numberOfFreeClusters;
      uint totalNumberOfClusters;
      GetDiskFreeSpace(String.Format(@"{0}\", driveLetter), out sectorsPerCluster, out bytesPerSector,
        out numberOfFreeClusters, out totalNumberOfClusters);
      Console.Out.WriteLine("Info for drive {0}", driveLetter);
      Console.Out.WriteLine("Bytes per sector: {0}", bytesPerSector);
            
      const int fatSerialOffset = 0x43;
      const int fatIdOffset = 0x52;
      const string fatFileSystemId = "FAT32";
      
      using (SafeFileHandle sfh = CreateFile(String.Format("\\\\.\\{0}", driveLetter), GenericRead | GenericWrite,
        (uint)FileShare.ReadWrite, IntPtr.Zero, OpenExisting, 0, IntPtr.Zero))
      {
        using (FileStream fs = new FileStream(sfh, FileAccess.ReadWrite))
        {
          byte[] firstSector = new byte[bytesPerSector];
          fs.Read(firstSector, 0, (int)bytesPerSector);
          if (Encoding.ASCII.GetString(firstSector, fatIdOffset, fatFileSystemId.Length) == fatFileSystemId)
          {
            Console.Out.WriteLine("FAT32 file system found...");
            uint serial = BitConverter.ToUInt32(firstSector, fatSerialOffset);
            Console.Out.WriteLine("Read serial number: {0:X4}-{1:X4}", serial >> 16, serial & 0xFFFF);
            // Write new serial number.
            byte[] newserial = BitConverter.GetBytes((uint)10000123);
            Array.Copy(newserial, 0, firstSector, fatSerialOffset, newserial.Length);
            fs.Seek(0, SeekOrigin.Begin);
            fs.Write(firstSector, 0, (int)bytesPerSector); 
          }                   
        }
      }
    }
