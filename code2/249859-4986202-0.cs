    [DllImport("kernel32.dll", CharSet=CharSet.Auto)]
    public static extern IntPtr GetModuleHandle(string lpModuleName);
    
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RendererData
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1692)]
        public byte[] Unknown;
        public byte ID07D54FC8;
        public byte DrawObjects;
        public byte DrawDeferred;
        // ...
        public byte DrawFPS;
        // ...
        public byte DrawSkyDome;
        // ...
    }
    
    void Main()
    {
        IntPtr rendererBase = GetModuleHandle("RendDx9.dll");
        if (rendererBase == IntPtr.Zero)
        {
            throw new InvalidOperationException("RendDx9.dll not found");
        }
        IntPtr rendererAddr = IntPtr.Add(rendererBase, 0x23D098);
    
        var data = new RendererData();
        Marshal.PtrToStructure(rendererAddr, data);
    
        data.DrawSkyDome = 0;
        data.DrawFPS = 1;
    
        Marshal.StructureToPtr(data, rendererAddr, false);
    }
