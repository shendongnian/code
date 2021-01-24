    PacketHeader packetheader = ByteArrayToPacketHeader(received);
    PacketHeader ByteArrayToPacketHeader(byte[] bytes)
    {
       GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
       PacketHeader stuff;
       try
       {
         stuff = (PacketHeader)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketHeader));
       }
       finally
       {
       handle.Free();
       }
       return stuff;
       }
