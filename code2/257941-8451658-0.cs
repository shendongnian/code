    /// <summary>
    /// Retrieves the platform information from the process architecture.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string GetPlatform(string path)
    {
        string result = "";
        try
        {
            const int pePointerOffset = 60;
            const int machineOffset = 4;
            var data = new byte[4096];
            using (Stream s = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                s.Read(data, 0, 4096);
            }
            // Dos header is 64 bytes, last element, long (4 bytes) is the address of 
            // the PE header
            int peHeaderAddr = BitConverter.ToInt32(data, pePointerOffset);
            int machineUint = BitConverter.ToUInt16(data, peHeaderAddr +
                                                          machineOffset);
            result = ((MachineType) machineUint).ToString();
        }
        catch { }
        return result;
    }
    public enum MachineType
    {
        Native = 0,
        X86 = 0x014c,
        Amd64 = 0x0200,
        X64 = 0x8664
    }
