    uint serialNum, serialNumLength, flags;
            StringBuilder volumename = new StringBuilder(256);
            StringBuilder fstype = new StringBuilder(256);
            bool ok = false;
            //Cursor.Current = Cursors.WaitCursor;
            foreach (string drives in Environment.GetLogicalDrives())
            {
                ok = GetVolumeInformation(drives, volumename, (uint)volumename.Capacity - 1, out serialNum,
                                       out serialNumLength, out flags, fstype, (uint)fstype.Capacity - 1);
                if (ok)
                {
                    Console.WriteLine( "\n Volume Information of " + drives + "\n");
                    Console.WriteLine( "\nSerialNumber of is..... " + serialNum.ToString() + " \n");
                    if (volumename != null)
                    {
                        Console.WriteLine("VolumeName is..... " + volumename.ToString() + " \n");
                    }
                    if (fstype != null)
                    {
                        Console.WriteLine( "FileType is..... " + fstype.ToString() + " \n");
                    }
                }
                ok = false;
            }
