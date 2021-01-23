    using System.Linq;
    using System.IO;
    using System;
    namespace DriveInfoExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Check only for fixed drives
                foreach (var di in DriveInfo.GetDrives().Where(d=>d.DriveType == DriveType.Fixed))
                {
                    Console.WriteLine("Free space on drive {0}\t{1} bytes", di.Name, di.AvailableFreeSpace);
                }
            }
        }
    }
