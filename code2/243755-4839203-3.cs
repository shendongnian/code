            NativeMethods.GetWindowThreadProcessId(hwndIcon, ref vProcessId);
            IntPtr vProcess = NativeMethods.OpenProcess(PROCESS_VM_OPERATION | PROCESS_VM_READ | PROCESS_VM_WRITE, false, vProcessId);
            IntPtr foo = IntPtr.Zero;
            IntPtr vPointer = NativeMethods.VirtualAllocEx(vProcess, IntPtr.Zero, sizeof(uint), MEM_RESERVE | MEM_COMMIT, PAGE_READWRITE);
                for (int j = 0; j < vItemCount; j++)
                {
                    byte[] vBuffer = new byte[256];
                    LVITEM[] vItem = new LVITEM[1];
                    vItem[0].mask = LVIF_TEXT;
                    vItem[0].iItem = j;
                    vItem[0].iSubItem = 0;
                    vItem[0].cchTextMax = vBuffer.Length;
                    vItem[0].pszText = (IntPtr)((int)vPointer + Marshal.SizeOf(typeof(LVITEM)));
                    uint vNumberOfBytesRead = 0;
                    WriteProcessMemory(vProcess, vPointer, Marshal.UnsafeAddrOfPinnedArrayElement(vItem, 0), Marshal.SizeOf(typeof(LVITEM)), ref vNumberOfBytesRead);
                    SendMessage(hwndIcon, LVM_GETITEMW, j, vPointer.ToInt32());
                    ReadProcessMemory(vProcess, (IntPtr)((int)vPointer + Marshal.SizeOf(typeof(LVITEM))), Marshal.UnsafeAddrOfPinnedArrayElement(vBuffer, 0), vBuffer.Length, out vNumberOfBytesRead);
                    // Get the name of the Icon
                    vText = Encoding.Unicode.GetString(vBuffer, 0, (int)vNumberOfBytesRead);
                    // Get  Icon location
                    SendMessage(hwndIcon, LVM_GETITEMPOSITION, j, vPointer.ToInt32());
                    Point[] vPoint = new Point[1];
                    foo = Marshal.UnsafeAddrOfPinnedArrayElement(vPoint, 0);
                    ReadProcessMemory(vProcess, vPointer, Marshal.UnsafeAddrOfPinnedArrayElement(vPoint, 0), Marshal.SizeOf(typeof(Point)), out vNumberOfBytesRead);
                   //and ultimaely move icon.
                   SendMessage(hwndIcon, LVM_SETITEMPOSITION, j, lParam[0]);
