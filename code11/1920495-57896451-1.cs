    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Random rand = new Random();
                List<byte> data = Enumerable.Range(0, 1000).Select(x => (byte)rand.Next(0,256)).ToList();
                ulong crc = Crc64.ComputeCrc64(data);
                List<byte> results = new List<byte>();
                for (int i = 7; i >= 0; i--)
                {
                    results.Add((byte)((crc >> (8 * i)) & 0xFF));
                }
                data.AddRange(results);
                ulong crc2 = Crc64.ComputeCrc64(data);
            }
        }
        public class Crc64
        {
            const ulong POLYNOMIAL = 0xD800000000000000;
            public static ulong ComputeCrc64(List<byte> data)
            {
                ulong crc = 0; /* CRC value is 64bit */
                foreach (byte b in data)
                {
                    crc ^= (ulong)b << 56; /* move byte into MSB of 63bit CRC */
                    for (int i = 0; i < 8; i++)
                    {
                        if ((crc & 0x8000000000000000) != 0) /* test for MSB = bit 63 */
                        {
                            crc = (ulong)((crc << 1) ^ POLYNOMIAL);
                        }
                        else
                        {
                            crc <<= 1;
                        }
                    }
                }
                return crc;
            }
        }
    }
