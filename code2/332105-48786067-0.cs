    /// <summary>
    /// A binary writer that packs data into bits, to preserve space when using many bit/boolean values. Up to about 87.5% cheaper for streams that only contains boolean values.
    /// By: jsmars@gmail.com, based on posters classes in this post: https://stackoverflow.com/questions/7051939/bit-based-binarywriter-in-c-sharp
    /// </summary>
    public class BinaryBitWriter : BinaryWriter
    {
        public byte BitPosition { get; private set; } = 0;
        private bool[] curByte = new bool[8];
        private System.Collections.BitArray ba;
        public BinaryBitWriter(Stream s) : base(s) { }
        public override void Flush()
        {
            flushBitBuffer();
            base.Flush();
        }
        public override void Write(byte[] buffer, int index, int count)
        {
            for (int i = index; i < index + count; i++)
                Write((byte)buffer[i]);
        }
        public override void Write(byte value)
        {
            ba = new BitArray(new byte[] { value });
            for (byte i = 0; i < 8; i++)
                Write(ba[i]);
        }
        public override void Write(bool value)
        {
            curByte[BitPosition] = value;
            BitPosition++;
            if (BitPosition == 8)
                flushBitBuffer();
        }
        public override void Write(char[] chars, int index, int count)
        {
            for (int i = index; i < index + count; i++)
                Write(chars[i]);
        }
        public override void Write(string value)
        {
            // write strings as normal for now, so flush the bits first
            flushBitBuffer();
            base.Write(value);
        }
        public override void Write(decimal value)
        {
            var ints = decimal.GetBits(value);
            for (int i = 0; i < ints.Length; i++)
                Write(ints[i]);
        }
        public override void Write(float value) => Write(BitConverter.GetBytes(value));
        public override void Write(ulong value) => Write(BitConverter.GetBytes(value));
        public override void Write(long value) => Write(BitConverter.GetBytes(value));
        public override void Write(uint value) => Write(BitConverter.GetBytes(value));
        public override void Write(int value) => Write(BitConverter.GetBytes(value));
        public override void Write(ushort value) => Write(BitConverter.GetBytes(value));
        public override void Write(short value) => Write(BitConverter.GetBytes(value));
        public override void Write(double value) => Write(BitConverter.GetBytes(value));
        public override void Write(char[] value) => Write(value, 0, value.Length);
        public override void Write(char value)
        {
            // write strings as normal for now, so flush the bits first
            flushBitBuffer();
            base.Write(value);
            //var b = BitConverter.GetBytes(value);
            //Write(b);
        }
        public override void Write(byte[] buffer) => Write(buffer, 0, buffer.Length);
        public override void Write(sbyte value) => Write((byte)value);
        void flushBitBuffer()
        {
            if (BitPosition == 0) // Nothing to flush
                return;
            base.Write(ConvertToByte(curByte));
            BitPosition = 0;
            curByte = new bool[8];
        }
        private static byte ConvertToByte(bool[] bools)
        {
            byte b = 0;
            byte bitIndex = 0;
            for (int i = 0; i < 8; i++)
            {
                if (bools[i])
                    b |= (byte)(((byte)1) << bitIndex);
                bitIndex++;
            }
            return b;
        }
    }
    public class BinaryBitReader : BinaryReader
    {
        public byte BitPosition { get; private set; } = 8;
        private bool[] curByte = new bool[8];
        public BinaryBitReader(Stream s) : base(s)
        {
            
        }
        public override bool ReadBoolean()
        {
            if (BitPosition == 8)
            {
                var ba = new BitArray(new byte[] { base.ReadByte() });
                ba.CopyTo(curByte, 0);
                BitPosition = 0;
            }
            bool b = curByte[BitPosition];
            BitPosition++;
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
        //public override int Read() => BitConverter.ToUInt64(ReadBytes(8), 0);
        public override int Read(byte[] buffer, int index, int count)
        {
            for (int i = index; i < index + count; i++)
                buffer[i] = ReadByte();
            return count; // we can return this here, it will die at the above row if anything is off
        }
        public override int Read(char[] buffer, int index, int count)
        {
            for (int i = index; i < index + count; i++)
                buffer[i] = ReadChar();
            return count; // we can return this here, it will die at the above row if anything is off
        }
        public override char ReadChar()
        {
            BitPosition = 8;
            return base.ReadChar();
            //BitConverter.ToChar(ReadBytes(2), 0);
        }
        public override char[] ReadChars(int count)
        {
            var chars = new char[count];
            Read(chars, 0, count);
            return chars;
        }
        public override decimal ReadDecimal()
        {
            int[] ints = new int[4];
            for (int i = 0; i < ints.Length; i++)
                ints[i] = ReadInt32();
            return new decimal(ints);
        }
        public override double ReadDouble() => BitConverter.ToDouble(ReadBytes(8), 0);
        public override short ReadInt16() => BitConverter.ToInt16(ReadBytes(2), 0);
        public override int ReadInt32() => BitConverter.ToInt32(ReadBytes(4), 0);
        public override long ReadInt64() => BitConverter.ToInt64(ReadBytes(8), 0);
        public override sbyte ReadSByte() => (sbyte)ReadByte();
        public override float ReadSingle() => BitConverter.ToSingle(ReadBytes(4), 0);
        public override string ReadString()
        {
            BitPosition = 8; // Make sure we read a new byte when we start reading the string
            return base.ReadString();
        }
        public override ushort ReadUInt16() => BitConverter.ToUInt16(ReadBytes(2), 0);
        public override uint ReadUInt32() => BitConverter.ToUInt32(ReadBytes(4), 0);
        public override ulong ReadUInt64() => BitConverter.ToUInt64(ReadBytes(8), 0);
    }
