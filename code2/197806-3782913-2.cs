    using (MemoryStream ms = new MemoryStream())
    {
        ms.WriteByte(0x00);
        ms.WriteByte(0x00);
        ms.WriteByte(0x03);
        ms.WriteByte(0xEB);
            
        ms.Position = 0;
        using (BinaryReader reader = new BinaryReader(ms))
        {
            byte[] temp = reader.ReadBytes(4);
            Array.Reverse(temp);
            int i = BitConverter.ToInt32(temp, 0);
        }
    }
