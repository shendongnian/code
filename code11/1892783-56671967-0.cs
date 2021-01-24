    using System;
    namespace crc16
    {
        class Program
        {
            private static ushort Crc16(byte[] bfr, int bfrlen)
            {
                ushort crc = 0;
                for (int i = 0; i < bfrlen; i++)
                {
                    crc ^= bfr[i];
                    for (int j = 0; j < 8; j++)
                        // assumes twos complement math
                        crc = (ushort)((crc >> 1)^((0 - (crc&1)) & 0xa001));
                }
                return crc;
            }
    
            static void Main(string[] args)
            {
                ushort crc;
                byte[] data = new byte[6] {0x11, 0x22, 0x33, 0x44, 0x00, 0x00};
                crc = Crc16(data, 4);           // generate crc
                data[4] = (byte)(crc & 0xff);   // append crc (lsb first)
                data[5] = (byte)(crc >> 8);
                crc = Crc16(data, 6);           // verify crc;
                Console.WriteLine("{0:X4}", crc);
                return;
            }
        }
    }
