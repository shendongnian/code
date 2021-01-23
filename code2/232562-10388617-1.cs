        public static void SendInput( ushort c )
        {
            // In 32 bit the IntPtr should be 4; it's 8 in 64 bit.
            if (Marshal.SizeOf(new IntPtr()) == 8)
            {
                SendInput64(c);
            }
            else
            {
                SendInput32(c);
            }
        }
