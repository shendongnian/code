    internal class BitField
    {
        private readonly byte[] _bytes;
        private readonly int _offset;
        private EndianBitConverter _bitConverter = EndianBitConverter.Big;
        public BitField(byte[] bytes)
            : this(bytes, 0)
        {
        }
        //offset = the offset (in bytes) into the wrapped byte array
        public BitField(byte[] bytes, int offset)
        {
            _bytes = bytes;
            _offset = offset;
        }
        public BitField(int size)
            : this(new byte[size], 0)
        {
        }
        //fill == true = initially set all bits to 1
        public BitField(int size, bool fill)
            : this(new byte[size], 0)
        {
            if (!fill) return;
            for(int i = 0 ; i < size ; i++)
            {
                _bytes[i] = 0xff;
            }
        }
        public byte[] Bytes
        {
            get { return _bytes; }
        }
        public int Offset
        {
            get { return _offset; }
        }
        public EndianBitConverter BitConverter
        {
            get { return _bitConverter; }
            set { _bitConverter = value; }
        }
        public bool this[int bit]
        {
            get { return IsBitSet(bit); }
            set { if (value) SetBit(bit); else ClearBit(bit); }
        }
        public bool IsBitSet(int bit)
        {
            return (_bytes[_offset + (bit / 8)] & (1 << (7 - (bit % 8)))) != 0;
        }
        public void SetBit(int bit)
        {
            _bytes[_offset + (bit / 8)] |= unchecked((byte)(1 << (7 - (bit % 8))));
        }
        public void ClearBit(int bit)
        {
            _bytes[_offset + (bit / 8)] &= unchecked((byte)~(1 << (7 - (bit % 8))));
        }
        //index = the index of the source BitField at which to start getting bits
        //length = the number of bits to get
        //size = the total number of bytes required (0 for arbitrary length return array)
        //fill == true = set all padding bits to 1
        public byte[] GetBytes(int index, int length, int size, bool fill)
        {
            if(size == 0) size = (length + 7) / 8;
            BitField bitField = new BitField(size, fill);
            for(int s = index, d = (size * 8) - length ; s < index + length && d < (size * 8) ; s++, d++)
            {
                bitField[d] = IsBitSet(s);
            }
            return bitField._bytes;
        }
        public byte[] GetBytes(int index, int length, int size)
        {
            return GetBytes(index, length, size, false);
        }
        public byte[] GetBytes(int index, int length)
        {
            return GetBytes(index, length, 0, false);
        }
        //bytesIndex = the index (in bits) into the bytes array at which to start copying
        //index = the index (in bits) in this BitField at which to put the value
        //length = the number of bits to copy from the bytes array
        public void SetBytes(byte[] bytes, int bytesIndex, int index, int length)
        {
            BitField bitField = new BitField(bytes);
            for (int i = 0; i < length; i++)
            {
                this[index + i] = bitField[bytesIndex + i];
            }
        }
        public void SetBytes(byte[] bytes, int index, int length)
        {
            SetBytes(bytes, 0, index, length);
        }
        public void SetBytes(byte[] bytes, int index)
        {
            SetBytes(bytes, 0, index, bytes.Length * 8);
        }
        //UInt16
        //index = the index (in bits) at which to start getting the value
        //length = the number of bits to use for the value, if less than required the value is padded with 0
        public ushort GetUInt16(int index, int length)
        {
            return _bitConverter.ToUInt16(GetBytes(index, length, 2), 0);
        }
        public ushort GetUInt16(int index)
        {
            return GetUInt16(index, 16);
        }
        //valueIndex = the index (in bits) of the value at which to start copying
        //index = the index (in bits) in this BitField at which to put the value
        //length = the number of bits to copy from the value
        public void Set(ushort value, int valueIndex, int index, int length)
        {
            SetBytes(_bitConverter.GetBytes(value), valueIndex, index, length);
        }
        public void Set(ushort value, int index)
        {
            Set(value, 0, index, 16);
        }
        //UInt32
        public uint GetUInt32(int index, int length)
        {
            return _bitConverter.ToUInt32(GetBytes(index, length, 4), 0);
        }
        public uint GetUInt32(int index)
        {
            return GetUInt32(index, 32);
        }
        public void Set(uint value, int valueIndex, int index, int length)
        {
            SetBytes(_bitConverter.GetBytes(value), valueIndex, index, length);
        }
        public void Set(uint value, int index)
        {
            Set(value, 0, index, 32);
        }
        //UInt64
        public ulong GetUInt64(int index, int length)
        {
            return _bitConverter.ToUInt64(GetBytes(index, length, 8), 0);
        }
        public ulong GetUInt64(int index)
        {
            return GetUInt64(index, 64);
        }
        public void Set(ulong value, int valueIndex, int index, int length)
        {
            SetBytes(_bitConverter.GetBytes(value), valueIndex, index, length);
        }
        public void Set(ulong value, int index)
        {
            Set(value, 0, index, 64);
        }
        //Int16
        public short GetInt16(int index, int length)
        {
            return _bitConverter.ToInt16(GetBytes(index, length, 2, IsBitSet(index)), 0);
        }
        public short GetInt16(int index)
        {
            return GetInt16(index, 16);
        }
        public void Set(short value, int valueIndex, int index, int length)
        {
            SetBytes(_bitConverter.GetBytes(value), valueIndex, index, length);
        }
        public void Set(short value, int index)
        {
            Set(value, 0, index, 16);
        }
        //Int32
        public int GetInt32(int index, int length)
        {
            return _bitConverter.ToInt32(GetBytes(index, length, 4, IsBitSet(index)), 0);
        }
        public int GetInt32(int index)
        {
            return GetInt32(index, 32);
        }
        public void Set(int value, int valueIndex, int index, int length)
        {
            SetBytes(_bitConverter.GetBytes(value), valueIndex, index, length);
        }
        public void Set(int value, int index)
        {
            Set(value, 0, index, 32);
        }
        //Int64
        public long GetInt64(int index, int length)
        {
            return _bitConverter.ToInt64(GetBytes(index, length, 8, IsBitSet(index)), 0);
        }
        public long GetInt64(int index)
        {
            return GetInt64(index, 64);
        }
        public void Set(long value, int valueIndex, int index, int length)
        {
            SetBytes(_bitConverter.GetBytes(value), valueIndex, index, length);
        }
        public void Set(long value, int index)
        {
            Set(value, 0, index, 64);
        }
        //Char
        public char GetChar(int index, int length)
        {
            return _bitConverter.ToChar(GetBytes(index, length, 2), 0);
        }
        public char GetChar(int index)
        {
            return GetChar(index, 16);
        }
        public void Set(char value, int valueIndex, int index, int length)
        {
            SetBytes(_bitConverter.GetBytes(value), valueIndex, index, length);
        }
        public void Set(char value, int index)
        {
            Set(value, 0, index, 16);
        }
        //Bool
        public bool GetBool(int index, int length)
        {
            return _bitConverter.ToBoolean(GetBytes(index, length, 1), 0);
        }
        public bool GetBool(int index)
        {
            return GetBool(index, 8);
        }
        public void Set(bool value, int valueIndex, int index, int length)
        {
            SetBytes(_bitConverter.GetBytes(value), valueIndex, index, length);
        }
        public void Set(bool value, int index)
        {
            Set(value, 0, index, 8);
        }
        //Single and double precision floating point values must always use the correct number of bits
        public float GetSingle(int index)
        {
            return _bitConverter.ToSingle(GetBytes(index, 32, 4), 0);
        }
        public void SetSingle(float value, int index)
        {
            SetBytes(_bitConverter.GetBytes(value), 0, index, 32);
        }
        public double GetDouble(int index)
        {
            return _bitConverter.ToDouble(GetBytes(index, 64, 8), 0);
        }
        public void SetDouble(double value, int index)
        {
            SetBytes(_bitConverter.GetBytes(value), 0, index, 64);
        }
    }
