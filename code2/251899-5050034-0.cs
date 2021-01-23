    private static bool injectMemory(IntPtr windowHandle, byte[] buffer, out IntPtr hndProc, out IntPtr lpAddress)
        {
            hndProc = IntPtr.Zero;
            lpAddress = IntPtr.Zero;
            //open local process object
            Process mainWindowProcess = FindProcess(windowHandle);
            hndProc = OpenProcess(
                (0x2 | 0x8 | 0x10 | 0x20 | 0x400), //create thread, query info, operation 
                //write, and read 
                1,
                (uint)mainWindowProcess.Id);
            if (hndProc == (IntPtr)0)
            {
                Console.WriteLine("Unable to attach process");
                return false;
            }
            //allocate memory for process object
            lpAddress = VirtualAllocEx(hndProc, (IntPtr)null, (uint)buffer.Length,
                 AllocationType.Commit | AllocationType.Reserve, MemoryProtection.ExecuteReadWrite);
            if (lpAddress == (IntPtr)0)
            {
                Console.WriteLine("Unable to allocate memory to target proces");
                return false;
            }
            //wite data
            uint wrotelen = 0;
            WriteProcessMemory(hndProc, lpAddress, buffer, (uint)buffer.Length, out wrotelen);
            if (Marshal.GetLastWin32Error() != 0)
            {
                Console.WriteLine("Unable to write memory to process.");
                return false;
            }
            return true;
        }
