    namespace MYC
    {
        public class CRC64
        {
            public const ulong POLY64    = 0x000000000000001B;
            public const ulong POLY64REV = 0xD800000000000000;
    
            public static ulong[] CRCTable;
            public static ulong[] revCRCTable;
    
            public static void generateTables()
            {
                ulong crc;
                byte b;
                b = 0;
                do
                {
                    crc = ((ulong)b)<<56;
                    for(int i = 0; i < 8; i++)
                        crc = (crc << 1) ^ ((0 - (crc >> 63)) & POLY64);
                    CRCTable[b] = crc;
                    b++;
                }while (b != 0);
                b = 0;
                do
                {
                    crc = ((ulong)b)<<0;
                    for(int i = 0; i < 8; i++)
                        crc = (crc >> 1) ^ ((0 - (crc & 1)) & POLY64REV);
                    revCRCTable[b] = crc;
                    b++;
                }while (b != 0);
            }
    
            static void Main(string[] args)
            {
                CRCTable = new ulong[256];
                revCRCTable = new ulong[256];
                generateTables();
            }
        }
    }
