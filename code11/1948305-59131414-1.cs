    NewMem MClass = new NewMem();
    
    var client = Process.GetProcessesByName("client_dx").FirstOrDefault();
    
    MClass.Process = client;
    
    // Get handle to process
    var hProc = NewMem.OpenProcess(0x00000010, false, client.Id);
    
    // Get base module
    var modBase = NewMem.GetModuleBaseAddress(client, "client_dx.exe");
    
    // Get relative base address
    var vBasePointer = NewMem.FindDMAAddy(hProc, (IntPtr)(modBase + 0x55F870), new int[] { 0 });
    
    // Get string
    if (vBasePointer != IntPtr.Zero)
    {
        var vNameAddress = vBasePointer + 0x20;
        var vName = MClass.ReadStringASCII(vNameAddress);
    }
