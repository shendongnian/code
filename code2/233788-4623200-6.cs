    public static void WriteMem(Process p, int address, long v)
    {
        var hProc = OpenProcess(ProcessAccessFlags.All, false, (int)p.Id);
        var val = new byte[] { (byte)v };
    
        int wtf = 0;
        WriteProcessMemory(hProc, new IntPtr(address), val, (UInt32)val.LongLength, out wtf);
        CloseHandle(hProc);
    }
