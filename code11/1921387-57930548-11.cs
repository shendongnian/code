    namespace crc64
    {
        public class crc64
        {
            public const ulong poly64f = 0x000000000000001bul;
            public const ulong poly64r = 0xd800000000000000ul;
            public const ulong crcin   = 0x0000000000000000ul; // initial value
            public const ulong xorot   = 0x0000000000000000ul; // xorout
    
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
            public static ulong crc64f(byte[] bfr, int len)
            {
                ulong crc = crcin;
                for(int i = 0; i < len; i++)
                    crc = (crc<<8)^(crctblf[(crc>>56)^bfr[i]]);
                return (crc^xorot);
            }
    
            // append forward crc
            public static void crc64fa(ulong crc, byte[] bfr, int pos)
            {
                bfr[pos+0] = (byte)(crc>>56);
                bfr[pos+1] = (byte)(crc>>48);
                bfr[pos+2] = (byte)(crc>>40);
                bfr[pos+3] = (byte)(crc>>32);
                bfr[pos+4] = (byte)(crc>>24);
                bfr[pos+5] = (byte)(crc>>16);
                bfr[pos+6] = (byte)(crc>> 8);
                bfr[pos+7] = (byte)(crc>> 0);
            }
    
            // change bfr to generate wanted forward crc
            public static void crc64fw(ulong crc, byte[] bfr, int len, int pos)
            {
                crc ^= crc64f(bfr, len);
                for(int i = pos; i < len; i++)
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
            public static ulong crc64r(byte[] bfr, int len)
            {
                ulong crc = crcin;
                for(int i = 0; i < len; i++)
                    crc = (crc>>8)^(crctblr[(crc&0xff)^bfr[i]]);
                return (crc^xorot);
            }
    
            // append reflected crc
            public static void crc64ra(ulong crc, byte[] bfr, int pos)
            {
                bfr[pos+0] = (byte)(crc>> 0);
                bfr[pos+1] = (byte)(crc>> 8);
                bfr[pos+2] = (byte)(crc>>16);
                bfr[pos+3] = (byte)(crc>>24);
                bfr[pos+4] = (byte)(crc>>32);
                bfr[pos+5] = (byte)(crc>>40);
                bfr[pos+6] = (byte)(crc>>48);
                bfr[pos+7] = (byte)(crc>>56);
            }
    
            // change bfr to generate wanted reflected crc
            public static void crc64rw(ulong crc, byte[] bfr, int len, int pos)
            {
                crc ^= crc64r(bfr, len);
                for (int i = pos; i < len; i++)
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
                byte[] bfr = {0x30,0x31,0x32,0x33,0x34,0x35,0x36,0x37,   // data (16 bytes)
                              0x38,0x39,0x61,0x62,0x63,0x64,0x65,0x66,
                              0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00};  // space for crc
                ulong crcf, crcr, crcw, crcg, crcs;
                int dl = bfr.Length-8;          // length of data
                int bl = bfr.Length;            // length of bfr
                gentbls();
                crcf = crc64f(bfr, dl);         // forward crc
                crc64fa(crcf, bfr, dl);         // append crc
                crcw = crc64f(bfr, bl);
                crcr = crc64r(bfr, dl);         // reflected crc
                crc64ra(crcr, bfr, dl);
                crcw = crc64r(bfr, bl);
                Console.WriteLine(crcf.ToString("x16") + " " + crcr.ToString("x16"));
                crcw = 0x0001020304050607ul;    // wanted crc
                crc64fw(crcw, bfr, dl, 8);      // "fix" for forward
                crcg = crc64f(bfr, dl);         // crcg should == crcw
                crc64fw(crcf, bfr, dl, 8);      // undo "fix for forward (restore bfr)
                crc64rw(crcw, bfr, dl, 8);      // "fix" for reflected
                crcs = crc64r(bfr, dl);         // crcs should == crcw
                Console.WriteLine(crcg.ToString("x16") + " " + crcs.ToString("x16"));
            }
        }
    }
