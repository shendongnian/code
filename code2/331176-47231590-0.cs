    public interface ISerializableClass
    {
        int SerializableClassSize { get; }
        StreamInflateTest Deserialize(byte[] buffer, int startOffset);
        byte[] Serialize(byte[] buffer, int startOffset);
    }
    public class   StreamInflateTest : ISerializableClass
    {
        private const int _classSize = 10;
        public float Float32Value { get; set; }
        public Int32 Int32Value { get; set; }
        public byte Byte8Value { get; set; }
        public bool IsOk0 { get; set; }
        public bool IsOk1 { get; set; }
        public bool IsOk2 { get; set; }
        public bool IsOk3 { get; set; }
        public bool IsOk4 { get; set; }
        public StreamInflateTest()
        {
        }
        public int SerializableClassSize { get { return _classSize; } }
        public StreamInflateTest(byte[] buffer, int startOffset)
        {
            Deserialize(buffer, startOffset);
        }
        public unsafe StreamInflateTest Deserialize(byte[] buffer, int startOffset)
        {
            fixed (byte* pb = &buffer[startOffset])
            {
                Float32Value = *(float*)pb;
                Int32Value = *(int*)(pb + 4);
                Byte8Value = pb[8];
                BitField8 bitfld = new BitField8(pb[9]);
                IsOk0 = bitfld.Bit0;
                IsOk1 = bitfld.Bit1;
                IsOk2 = bitfld.Bit2;
                IsOk3 = bitfld.Bit3;
                IsOk4 = bitfld.Bit4;
            }
            return this;
        }
        public unsafe byte[] Serialize(byte[] buffer, int startOffset)
        {
            fixed (byte* pb = &buffer[startOffset])
            {
                *(float*)pb = Float32Value;
                *(int*)(pb + 4) = Int32Value;
                pb[8] = Byte8Value;
                BitField8 bitfld = new BitField8(0)
                {
                    Bit0 = IsOk0,
                    Bit1 = IsOk1,
                    Bit2 = IsOk2,
                    Bit3 = IsOk3,
                    Bit4 = IsOk4
                };
                pb[9] = bitfld.Value;
            }
            return buffer;
        }
    }
    public struct BitField8
    {
        public byte Value;
        public BitField8(byte value)
        {
            Value = value;
        }
        public bool Bit0
        {
            get { return (Value & 0x01) != 0; }
            set
            {
                if (value)
                    Value |= 0x01;
                else
                    Value = (byte)(Value & 0xFE);  // clear the bit
            }
        }
        public bool Bit1
        {
            get { return (Value & 0x02) != 0; }
            set
            {
                if (value)
                    Value |= 0x02;
                else
                    Value = (byte)(Value & 0xFD);  // clear the bit
            }
        }
        public bool Bit2
        {
            get { return (Value & 0x04) != 0; }
            set
            {
                if (value)
                    Value |= 0x04;
                else
                    Value = (byte)(Value & 0xFB);  // clear the bit
            }
        }
        public bool Bit3
        {
            get { return (Value & 0x08) != 0; }
            set
            {
                if (value)
                    Value |= 0x08;
                else
                    Value = (byte)(Value & 0xF7);  // clear the bit
            }
        }
        public bool Bit4
        {
            get { return (Value & 0x10) != 0; }
            set
            {
                if (value)
                    Value |= 0x10;
                else
                    Value = (byte)(Value & 0xEF);  // clear the bit
            }
        }
        public bool Bit5
        {
            get { return (Value & 0x20) != 0; }
            set
            {
                if (value)
                    Value |= 0x20;
                else
                    Value = (byte)(Value & 0xDF);  // clear the bit
            }
        }
        public bool Bit6
        {
            get { return (Value & 0x40) != 0; }
            set
            {
                if (value)
                    Value |= 0x40;
                else
                    Value = (byte)(Value & 0xBF);  // clear the bit
            }
        }
        public bool Bit7
        {
            get { return (Value & 0x80) != 0; }
            set
            {
                if (value)
                    Value |= 0x80;
                else
                    Value = (byte)(Value & 0x7F);  // clear the bit
            }
        }
        public bool Set(bool value, int bitNo)
        {
            if (bitNo > 7 || bitNo < 0)
                throw new ArgumentOutOfRangeException();
            if (value)
                Value |= (byte)(0x01 << bitNo);
            else
                Value = (byte)(Value & ~(0x01 << bitNo));  // clear the bit
            return value;
        }
        public bool Get(int bitNo)
        {
            if (bitNo > 7 || bitNo < 0)
                throw new ArgumentOutOfRangeException();
            return ((Value >> bitNo) & 0x01) != 0;
        }
        public bool this[int bitNo]
        {
            get { return Get(bitNo); }
            set { Set(value, bitNo); }
        }
    }
