         public sealed class UnixDBCSPages
         {
            public static readonly uint JIS           = MakeUnixDBCS(Convert.ToUInt32(0x0C));
            public static readonly uint EUCJP         = MakeUnixDBCS(Convert.ToUInt32(0x0D));
            public static readonly uint CNS11643_1    = MakeUnixDBCS(3);
            public static readonly uint EUC_CNS_1     = MakeUnixDBCS(7) ;                             
            public static readonly uint CNS11643_2    = MakeUnixDBCS(4) ;
            public static readonly uint EUC_CNS_2     = MakeUnixDBCS(8);                             
            public static readonly uint KSC1987       = MakeUnixDBCS(6);
            public static readonly uint GB2312        = MakeUnixDBCS(5);
            private static uint MakeUnixDBCS(uint wCodePage)
            {
                uint wUnixUnmask = Convert.ToUInt32(Flags.UnixUnmask);                
                return (wUnixUnmask | wCodePage) << 16;
            }
        }
 
