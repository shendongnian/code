        struct TCP_INFO_v0
        {
            public UInt32 State;
            public UInt32 Mss;
            public UInt64 ConnectionTimeMs;
            public byte TimestampsEnabled;
            public UInt32 RttUs;
            public UInt32 MinRttUs;
            public UInt32 BytesInFlight;
            public UInt32 Cwnd;
            public UInt32 SndWnd;
            public UInt32 RcvWnd;
            public UInt32 RcvBuf;
            public UInt64 BytesOut;
            public UInt64 BytesIn;
            public UInt32 BytesReordered;
            public UInt32 BytesRetrans;
            public UInt32 FastRetrans;
            public UInt32 DupAcksIn;
            public UInt32 TimeoutEpisodes;
            public byte SynRetrans;
        }
        // SIO_TCP_INFO as defined in winsdk-10/mstcpip.h
        readonly static int SIO_TCP_INFO = unchecked((int)0xD8000027);
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient("127.0.0.1", 445);
            var outputArray = new byte[128];
            tcpClient.Client.IOControl(SIO_TCP_INFO, BitConverter.GetBytes(0), outputArray);
            GCHandle handle = GCHandle.Alloc(outputArray, GCHandleType.Pinned);
            TCP_INFO_v0 tcpInfo = (TCP_INFO_v0)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(TCP_INFO_v0));
            handle.Free();
            Console.WriteLine("Bytes retransmitted: {0}", tcpInfo.BytesRetrans);
        }
