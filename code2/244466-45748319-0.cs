    // firstly we have the handle to the list view:
    var listViewPtr = this.GetListViewHandle();
    // get the ID of the process who owns the list view
    WinAPI.GetWindowThreadProcessId(listViewPtr, out var processId);
    // open the process
	var processHandle = WinAPI.OpenProcess(
		WinAPI.ProcessAccessFlags.VirtualMemoryOperation
		| WinAPI.ProcessAccessFlags.VirtualMemoryRead
		| WinAPI.ProcessAccessFlags.VirtualMemoryWrite,
		false,
		processId);
    // allocate buffer for a string to store the text of the list view item we want to get
	var textBufferPtr = WinAPI.VirtualAllocEx(
		processHandle,
		IntPtr.Zero,
		WinAPI.MAX_LVMSTRING,
		WinAPI.AllocationType.Commit,
		WinAPI.MemoryProtection.ReadWrite);
    // this is the LVITEM we need to inject
	var lvItem = new WinAPI.LVITEM
	{
		mask = (uint)WinAPI.ListViewItemFilters.LVIF_TEXT,
		cchTextMax = (int)WinAPI.MAX_LVMSTRING,
		pszText = textBufferPtr,
		iItem = 0,    // the item (row) index
		iSubItem = 1    // the subitem (column) index
	};
	// marshal the LVITEM structure into unmanaged memory so it can be written into textBufferPtr
    // allocate memory for the LVITEM structure in the remote process
	var lvItemSize = Marshal.SizeOf(lvItem);
	var lvItemBufferPtr = WinAPI.VirtualAllocEx(
		processHandle,
		IntPtr.Zero,
		(uint)lvItemSize,
		WinAPI.AllocationType.Commit,
		WinAPI.MemoryProtection.ReadWrite);
	// to inject the LVITEM structure, we have to use the WriteProcessMemory API, which does a pointer-to-pointer copy. So we need to turn the managed LVITEM structure to an unmanaged LVITEM pointer
    // first allocate a piece of unmanaged memory ...
	var lvItemLocalPtr = Marshal.AllocHGlobal(lvItemSize);
    // ... then copy the managed object into the unmanaged memory
	Marshal.StructureToPtr(lvItem, lvItemLocalPtr, false);
    // and write into remote process's memory
	WinAPI.WriteProcessMemory(
		processHandle,
		lvItemBufferPtr,
		lvItemLocalPtr,
		(uint)lvItemSize,
		out var _);
    // tell the list view to fill in the text we desired
	WinAPI.SendMessage(listViewPtr, (int)WinAPI.ListViewMessages.LVM_GETITEMTEXT, itemId, lvItemBufferPtr);
    // read the text. we allocate a managed byte array to store the retrieved text instead of AllocHGlobal-ing a piece of unmanaged memory, because CLR knows how to marshal between a pointer and a byte array
	var localTextBuffer = new byte[WinAPI.MAX_LVMSTRING];
	WinAPI.ReadProcessMemory(
		processHandle,
		textBufferPtr,
		localTextBuffer,
		(int)WinAPI.MAX_LVMSTRING,
		out var _);
    // convert the byte array to a string. assume the remote process uses Unicode
	var text = Encoding.Unicode.GetString(localTextBuffer);
    // the trailing zeros are not cleared automatically
	text = text.Substring(0, text.IndexOf('\0'));
    // finally free all the memory we allocated, and close the process handle we opened
	WinAPI.VirtualFreeEx(processHandle, textBufferPtr, 0, WinAPI.AllocationType.Release);
	WinAPI.VirtualFreeEx(processHandle, lvItemBufferPtr, 0, WinAPI.AllocationType.Release);
	Marshal.FreeHGlobal(lvItemLocalPtr);
	WinAPI.CloseHandle(processHandle);
