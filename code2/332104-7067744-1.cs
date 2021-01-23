    private class BinaryReader : System.IO.BinaryReader
    {
        private bool[] curByte = new bool[8];
        private byte curBitIndx = 0;
        private BitArray ba;
        public BinaryReader(Stream s) : base(s)
        {
            ba = new BitArray(new byte[] { base.ReadByte() });
            ba.CopyTo(curByte, 0);
            ba = null;
        }
        public override bool ReadBoolean()
        {
            if (curBitIndx == 8)
            {
                ba = new BitArray(new byte[] { base.ReadByte() });
                ba.CopyTo(curByte, 0);
                ba = null;
                this.curBitIndx = 0;
            }
            bool b = curByte[curBitIndx];
            curBitIndx++;
            return b;
        }
        public override byte ReadByte()
        {
            bool[] bar = new bool[8];
            byte i;
            for (i = 0; i < 8; i++)
            {
                bar[i] = this.ReadBoolean();
            }
            byte b = 0;
            byte bitIndex = 0;
            for (i = 0; i < 8; i++)
            {
                if (bar[i])
                {
                    b |= (byte)(((byte)1) << bitIndex);
                }
                bitIndex++;
            }
            return b;
        }
        public override byte[] ReadBytes(int count)
        {
            byte[] bytes = new byte[count];
            for (int i = 0; i < count; i++)
            {
                bytes[i] = this.ReadByte();
            }
            return bytes;
        }
        public override ushort ReadUInt16()
        {
            byte[] bytes = ReadBytes(2);
            return BitConverter.ToUInt16(bytes, 0);
        }
        public override uint ReadUInt32()
        {
            byte[] bytes = ReadBytes(4);
            return BitConverter.ToUInt32(bytes, 0);
        }
        public override ulong ReadUInt64()
        {
            byte[] bytes = ReadBytes(8);
            return BitConverter.ToUInt64(bytes, 0);
        }
    }
