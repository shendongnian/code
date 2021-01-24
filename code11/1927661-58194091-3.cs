    bool ValidateZip(FileStream fs)
    {
        using (BinaryReader br = new BinaryReader(fs))
        {
            br.BaseStream.Seek(-22, SeekOrigin.End);
            return br.ReadUInt32() == 0x06054b50;
        }
    }
