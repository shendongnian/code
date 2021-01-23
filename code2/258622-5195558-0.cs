    using System;
    using System.Runtime.InteropServices;
    
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    struct Message
    {
        public int id;
        [MarshalAs (UnmanagedType.ByValTStr, SizeConst=50)] 
        public string text;
    }
    
    void OnPacket(byte[] packet)
    {
        GCHandle pinnedPacket = GCHandle.Alloc(packet, GCHandleType.Pinned);
        Message msg = (Message)Marshal.PtrToStructure(
            pinnedPacket.AddrOfPinnedObject(),
            typeof(Message));        
        pinnedPacket.Free();
    }
