    bool ValidateZip(FileStream fs)
    {
        using (BinaryReader br = new BinaryReader(fs))
        {
            br.BaseStream.Seek(-22, SeekOrigin.End);
            uint sig = br.ReadUInt32();
            return sig == 0x06054b50 ? true : false;
        }
    }
