	using static System.Net.IPAddress;
	namespace BigEndianExtension
    {
        public static class BigEndian
        {
            public static short ToBigEndian(this short value)   => HostToNetworkOrder(value);
            public static int   ToBigEndian(this int value)     => HostToNetworkOrder(value);
            public static long  ToBigEndian(this long value)    => HostToNetworkOrder(value);
            public static short FromBigEndian(this short value) => NetworkToHostOrder(value);
            public static int   FromBigEndian(this int value)   => NetworkToHostOrder(value);
            public static long  FromBigEndian(this long value)  => NetworkToHostOrder(value);
        }
    }
