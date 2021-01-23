    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace cSharpServer
    {
        public class BinaryBuffer
        {
            private const string Str0001 = "You are at the End of File!";
            private const string Str0002 = "You are Not Reading from the Buffer!";
            private const string Str0003 = "You are Currenlty Writing to the Buffer!";
            private const string Str0004 = "You are Currenlty Reading from the Buffer!";
            private const string Str0005 = "You are Not Writing to the Buffer!";
            private const string Str0006 = "You are trying to Reverse Seek, Unable to add a Negative value!";
            private bool _inRead;
            private bool _inWrite;
            private List<byte> _newBytes;
            private int _pointer;
            public byte[] ByteBuffer;
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public override string ToString()
            {
                return Helper.DefaultEncoding.GetString(ByteBuffer, 0, ByteBuffer.Length);
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public BinaryBuffer(string data)
                : this(Helper.DefaultEncoding.GetBytes(data))
            {
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public BinaryBuffer()
            {
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public BinaryBuffer(byte[] data)
                : this(ref data)
            {
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public BinaryBuffer(ref byte[] data)
            {
                ByteBuffer = data;
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void IncrementPointer(int add)
            {
                if (add < 0)
                {
                    throw new Exception(Str0006);
                }
                _pointer += add;
                if (EofBuffer())
                {
                    throw new Exception(Str0001);
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int GetPointer()
            {
                return _pointer;
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static string GetString(ref byte[] buffer)
            {
                return Helper.DefaultEncoding.GetString(buffer, 0, buffer.Length);
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static string GetString(byte[] buffer)
            {
                return GetString(ref buffer);
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void BeginWrite()
            {
                if (_inRead)
                {
                    throw new Exception(Str0004);
                }
                _inWrite = true;
    
                _newBytes = new List<byte>();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Write(float value)
            {
                if (!_inWrite)
                {
                    throw new Exception(Str0005);
                }
                _newBytes.AddRange(BitConverter.GetBytes(value));
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Write(byte value)
            {
                if (!_inWrite)
                {
                    throw new Exception(Str0005);
                }
                _newBytes.Add(value);
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Write(int value)
            {
                if (!_inWrite)
                {
                    throw new Exception(Str0005);
                }
    
                _newBytes.AddRange(BitConverter.GetBytes(value));
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Write(long value)
            {
                if (!_inWrite)
                {
                    throw new Exception(Str0005);
                }
                byte[] byteArray = new byte[8];
    
                unsafe
                {
                    fixed (byte* bytePointer = byteArray)
                    {
                        *((long*)bytePointer) = value;
                    }
                }
    
                _newBytes.AddRange(byteArray);
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int UncommitedLength()
            {
                return _newBytes == null ? 0 : _newBytes.Count;
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void WriteField(string value)
            {
                Write(value.Length);
                Write(value);
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Write(string value)
            {
                if (!_inWrite)
                {
                    throw new Exception(Str0005);
                }
                byte[] byteArray = Helper.DefaultEncoding.GetBytes(value);
                _newBytes.AddRange(byteArray);
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Write(decimal value)
            {
                if (!_inWrite)
                {
                    throw new Exception(Str0005);
                }
                int[] intArray = decimal.GetBits(value);
    
                Write(intArray[0]);
                Write(intArray[1]);
                Write(intArray[2]);
                Write(intArray[3]);
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void SetInt(int value, int pos)
            {
                byte[] byteInt = BitConverter.GetBytes(value);
                for (int i = 0; i < byteInt.Length; i++)
                {
                    _newBytes[pos + i] = byteInt[i];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void SetLong(long value, int pos)
            {
                byte[] byteInt = BitConverter.GetBytes(value);
                for (int i = 0; i < byteInt.Length; i++)
                {
                    _newBytes[pos + i] = byteInt[i];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Write(byte[] value)
            {
                Write(ref value);
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Write(ref byte[] value)
            {
                if (!_inWrite)
                {
                    throw new Exception(Str0005);
                }
                _newBytes.AddRange(value);
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void EndWrite()
            {
                if (ByteBuffer != null)
                {
                    _newBytes.InsertRange(0, ByteBuffer);
                }
                ByteBuffer = _newBytes.ToArray();
                _newBytes = null;
                _inWrite = false;
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void EndRead()
            {
                _inRead = false;
                _pointer = 0;
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void BeginRead()
            {
                if (_inWrite)
                {
                    throw new Exception(Str0003);
                }
                _inRead = true;
                _pointer = 0;
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public byte ReadByte()
            {
                if (!_inRead)
                {
                    throw new Exception(Str0002);
                }
                if (EofBuffer())
                {
                    throw new Exception(Str0001);
                }
                return ByteBuffer[_pointer++];
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int ReadInt()
            {
                if (!_inRead)
                {
                    throw new Exception(Str0002);
                }
                if (EofBuffer(4))
                {
                    throw new Exception(Str0001);
                }
                int startPointer = _pointer;
                _pointer += 4;
    
                return BitConverter.ToInt32(ByteBuffer, startPointer);
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public float[] ReadFloatArray()
            {
                float[] dataFloats = new float[ReadInt()];
                for (int i = 0; i < dataFloats.Length; i++)
                {
                    dataFloats[i] = ReadFloat();
                }
                return dataFloats;
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public float ReadFloat()
            {
                if (!_inRead)
                {
                    throw new Exception(Str0002);
                }
                if (EofBuffer(sizeof(float)))
                {
                    throw new Exception(Str0001);
                }
                int startPointer = _pointer;
                _pointer += sizeof(float);
    
                return BitConverter.ToSingle(ByteBuffer, startPointer);
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public decimal ReadDecimal()
            {
                if (!_inRead)
                {
                    throw new Exception(Str0002);
                }
                if (EofBuffer(16))
                {
                    throw new Exception(Str0001);
                }
                return new decimal(new[] { ReadInt(),
    				ReadInt(),
    				ReadInt(),
    				ReadInt()
    			});
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public long ReadLong()
            {
                if (!_inRead)
                {
                    throw new Exception(Str0002);
                }
                if (EofBuffer(8))
                {
                    throw new Exception(Str0001);
                }
                int startPointer = _pointer;
                _pointer += 8;
    
                return BitConverter.ToInt64(ByteBuffer, startPointer);
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public string ReadString(int size)
            {
                return Helper.DefaultEncoding.GetString(ReadByteArray(size), 0, size);
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public byte[] ReadByteArray(int size)
            {
                if (!_inRead)
                {
                    throw new Exception(Str0002);
                }
                if (EofBuffer(size))
                {
                    throw new Exception(Str0001);
                }
                byte[] newBuffer = new byte[size];
    
                Array.Copy(ByteBuffer, _pointer, newBuffer, 0, size);
    
                _pointer += size;
    
                return newBuffer;
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool EofBuffer(int over = 1)
            {
                return ByteBuffer == null || ((_pointer + over) > ByteBuffer.Length);
            }
        }
    }
