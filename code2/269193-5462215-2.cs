    using (Filestream fs = File.OpenRead(Path))
    {
        using (BinaryReader br = new BinaryReader(fs))
        {
            myByte = br.ReadByte();
        }
    }
