    Process process;
    process = Process.GetProcessesByName("ac_client")[0];
    var hProc = OpenProcess(0x001F0FFF, false, process.Id);
    var modBase = GetModuleBaseAddress(process, "ac_client.exe");
    var addr = FindDMAAddy(hProc, (IntPtr)(modBase + 0x10f4f4), new int[] { 0x374, 0x14, 0 });
    Console.WriteLine("0x" + addr.ToString("X"));
    Console.ReadKey();
