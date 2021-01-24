    namespace MYC
    {
        public class CRC64
        {
            public const ulong poly64f = 0x000000000000001bul;
            public const ulong poly64r = 0xd800000000000000ul;
            public const ulong xorout  = 0x0000000000000000ul;
    
            public static ulong[] crctblf;          // fwd tbl
            public static ulong[] crctblg;          // fwd tbl backwards cycle
            public static ulong[] crctblr;          // ref tbl
            public static ulong[] crctbls;          // ref tbl backwards cycle
    
            // generate tables
            public static void gentbls()
            {
                ulong crc;
                byte b;
                b = 0;
                do
                {
                    crc = ((ulong)b)<<56;
                    for(int i = 0; i < 8; i++)
                        crc = (crc<<1)^((0-(crc>>63))&poly64f);
                    crctblf[b] = crc;
                    b++;
                }while (b != 0);
                do
                {
                    crc = ((ulong)b) << 0;
                    for (int i = 0; i < 8; i++)
                        crc = (crc<<63)^((crc^((0-(crc&1))&poly64f))>>1);
                    crctblg[b] = crc;
                    b++;
                } while (b != 0);
                do
                {
                    crc = ((ulong)b)<<0;
                    for(int i = 0; i < 8; i++)
                        crc = (crc>>1)^((0-(crc&1))&poly64r);
                    crctblr[b] = crc;
                    b++;
                }while (b != 0);
                do
                {
                    crc = ((ulong)b) << 56;
                    for (int i = 0; i < 8; i++)
                        crc = (crc>>63)^((crc^((0-(crc>>63))&poly64r))<<1);
                    crctbls[b] = crc;
                    b++;
                } while (b != 0);
            }
    
            // generate forward crc
            public static ulong crc32f(ulong crc, byte[] bfr)
            {
                foreach (byte b in bfr)
                    crc = (crc<<8)^(crctblf[(crc>>56)^b]);
                return (crc^xorout);
            }
    
            // change bfr to generate wanted forward crc
            public static void crc32fw(ulong crc, byte[] bfr, int pos)
            {
                crc ^= crc32f(0, bfr);
                for(int i = pos; i < bfr.Length; i++)
                    crc = (crc>>8)^(crctblg[crc&0xff]);
                bfr[pos+0] ^= (byte)(crc>>56);
                bfr[pos+1] ^= (byte)(crc>>48);
                bfr[pos+2] ^= (byte)(crc>>40);
                bfr[pos+3] ^= (byte)(crc>>32);
                bfr[pos+4] ^= (byte)(crc>>24);
                bfr[pos+5] ^= (byte)(crc>>16);
                bfr[pos+6] ^= (byte)(crc>> 8);
                bfr[pos+7] ^= (byte)(crc>> 0);
            }
    
            // generate reflected crc
            public static ulong crc32r(ulong crc, byte[] bfr)
            {
                foreach (byte b in bfr)
                    crc = (crc>>8)^(crctblr[(crc&0xff)^b]);
                return (crc^xorout);
            }
    
            // change bfr to generate wanted reflected crc
            public static void crc32rw(ulong crc, byte[] bfr, int pos)
            {
                crc ^= crc32r(0, bfr);
                for (int i = pos; i < bfr.Length; i++)
                    crc = (crc<<8)^(crctbls[crc>>56]);
                bfr[pos+0] ^= (byte)(crc>> 0);
                bfr[pos+1] ^= (byte)(crc>> 8);
                bfr[pos+2] ^= (byte)(crc>>16);
                bfr[pos+3] ^= (byte)(crc>>24);
                bfr[pos+4] ^= (byte)(crc>>32);
                bfr[pos+5] ^= (byte)(crc>>40);
                bfr[pos+6] ^= (byte)(crc>>48);
                bfr[pos+7] ^= (byte)(crc>>56);
            }
    
            static void Main(string[] args)
            {
                crctblf = new ulong[256];
                crctblg = new ulong[256];
                crctblr = new ulong[256];
                crctbls = new ulong[256];
                byte[] bfr = {0x30,0x31,0x32,0x33,0x34,0x35,0x36,0x37,
                              0x38,0x39,0x61,0x62,0x63,0x64,0x65,0x66};
                gentbls();
                ulong crcf = crc32f(0, bfr);        // forward crc
                ulong crcr = crc32r(0, bfr);        // reflected crc
                Console.WriteLine(crcf.ToString("x16") + " " + crcr.ToString("x16"));
                ulong crcw = 0x0001020304050607ul;  // wanted crc
                crc32fw(crcw, bfr, 8);              // "fix" for forward
                ulong crcg = crc32f(0, bfr);        // crcg should == crcw
                crc32rw(crcw, bfr, 8);              // "fix" for reflected
                ulong crcs = crc32r(0, bfr);        // crcs should == crcw
                Console.WriteLine(crcg.ToString("x16") + " " + crcs.ToString("x16"));
            }
        }
    }
