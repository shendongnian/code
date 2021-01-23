    public unsafe FileEntry Get(Stream src)
    {
         FileEntry fe = new FileEntry();
         var br = new BinaryReader(src);
         fe.Value1 = br.ReadByte();
         ...
    }
