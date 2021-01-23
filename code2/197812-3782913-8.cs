    using (MemoryStream ms = new MemoryStream())
    {
        // write bytes in big-endian format
        ms.WriteByte(0x00);
        ms.WriteByte(0x00);
        ms.WriteByte(0x03);
        ms.WriteByte(0xEB);
            
        ms.Position = 0;
        using (BinaryReader reader = new BinaryReader(ms))
        {
            byte[] temp = reader.ReadBytes(4);
            if (BitConverter.IsLittleEndian)
            {
                // reverse the byte order only if we are on a little-endian system,
                // because the BitConverter is aware of the endianness of the system
                //
                Array.Reverse(temp);
            }
            int i = BitConverter.ToInt32(temp, 0);
        }
    }
