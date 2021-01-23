    private class BinaryWriter : System.IO.BinaryWriter
    {
        private bool[] curByte = new bool[8];
        private byte curBitIndx = 0;
        private System.Collections.BitArray ba;
        public BinaryWriter(Stream s) : base(s) { }
        public override void Flush()
        {
            base.Write(ConvertToByte(curByte));
            base.Flush();
        }
        public override void Write(bool value)
        {
            curByte[curBitIndx] = value;
            curBitIndx++;
            if (curBitIndx == 8)
            {
                base.Write(ConvertToByte(curByte));
                this.curBitIndx = 0;
                this.curByte = new bool[8];
            }
        }
        public override void Write(byte value)
        {
            ba = new BitArray(new byte[] { value });
            for (byte i = 0; i < 8; i++)
            {
                this.Write(ba[i]);
            }
            ba = null;
        }
        public override void Write(byte[] buffer)
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                this.Write((byte)buffer[i]);
            }
        }
        public override void Write(uint value)
        {
            ba = new BitArray(BitConverter.GetBytes(value));
            for (byte i = 0; i < 32; i++)
            {
                this.Write(ba[i]);
            }
            ba = null;
        }
        public override void Write(ulong value)
        {
            ba = new BitArray(BitConverter.GetBytes(value));
            for (byte i = 0; i < 64; i++)
            {
                this.Write(ba[i]);
            }
            ba = null;
        }
        public override void Write(ushort value)
        {
            ba = new BitArray(BitConverter.GetBytes(value));
            for (byte i = 0; i < 16; i++)
            {
                this.Write(ba[i]);
            }
            ba = null;
        }
        private static byte ConvertToByte(bool[] bools)
        {
            byte b = 0;
            byte bitIndex = 0;
            for (int i = 0; i < 8; i++)
            {
                if (bools[i])
                {
                    b |= (byte)(((byte)1) << bitIndex);
                }
                bitIndex++;
            }
            return b;
        }
    }
