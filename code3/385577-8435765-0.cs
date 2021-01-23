        [DllImport("WININET", CharSet = CharSet.Auto)]
        static extern bool InternetGetConnectedState(ref int lpdwFlags, int dwReserved);
        public static bool Connected
        {
            get
            {
                int flags = 0;
                return InternetGetConnectedState(ref flags, 0);
            }
        }
