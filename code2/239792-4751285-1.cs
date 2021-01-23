    using System;
    using System.Diagnostics;
    
    namespace netduino
    {
        public static class BitConverter
        {
            public static byte[] GetBytes(uint value)
            {
                return new byte[4] { 
                        (byte)(value & 0xFF), 
                        (byte)((value >> 8) & 0xFF), 
                        (byte)((value >> 16) & 0xFF), 
                        (byte)((value >> 24) & 0xFF) };
            }
    
            public static unsafe byte[] GetBytes(float value)
            {
                uint val = *((uint*)&value);
                return GetBytes(val);
            }
    
            public static unsafe byte[] GetBytes(float value, ByteOrder order)
            {
                byte[] bytes = GetBytes(value);
                if (order != ByteOrder.LittleEndian)
                {
                    System.Array.Reverse(bytes);
                }
                return bytes;
            }
    
            public static uint ToUInt32(byte[] value, int index)
            {
                return (uint)(
                    value[0 + index] << 0 |
                    value[1 + index] << 8 |
                    value[2 + index] << 16 |
                    value[3 + index] << 24);
            }
    
            public static unsafe float ToSingle(byte[] value, int index)
            {
                uint i = ToUInt32(value, index);
                return *(((float*)&i));
            }
    
            public static unsafe float ToSingle(byte[] value, int index, ByteOrder order)
            {
                if (order != ByteOrder.LittleEndian)
                {
                    System.Array.Reverse(value, index, value.Length);
                }
                return ToSingle(value, index);
            }
    
            public enum ByteOrder
            {
                LittleEndian,
                BigEndian
            }
    
            static public bool IsLittleEndian
            {
                get
                {
                    unsafe
                    {
                        int i = 1;
                        char* p = (char*)&i;
    
                        return (p[0] == 1);
                    }
                }
            }
        }
    }
    
    namespace BitConverterTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                byte[] msbFirst = new byte[] { 0x42, 0xF6, 0xE9, 0xE0 };
                byte[] lsbFirst = new byte[] { 0xE0, 0xE9, 0xF6, 0x42 };
                const float f = 123.456789F;
    
                byte[] b = netduino.BitConverter.GetBytes(f, netduino.BitConverter.ByteOrder.BigEndian);
                for (int i = 0; i < b.Length; i++)
                {
                    Debug.Assert(msbFirst[i] == b[i], "BitConverter.GetBytes(float, BigEndian) i=" + i);
                }
    
                Debug.Assert(f == netduino.BitConverter.ToSingle(msbFirst, 0, netduino.BitConverter.ByteOrder.BigEndian));
    
                Console.WriteLine("All tests passed");
                Console.ReadKey();
            }
        }
    }
